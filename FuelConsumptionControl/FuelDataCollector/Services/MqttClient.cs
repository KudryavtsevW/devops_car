using System.Text.Json;
using MQTTnet;
using MQTTnet.Client;

namespace FuelConsumptionControl.Services;

public class MqttClient : IDataProviderClient
{
	public async Task SendMessage(object message, int clientId)
	{
		await SendMessage(JsonSerializer.Serialize(message), clientId);
	}

	public async Task SendMessage(string message, int clientId)
	{
		var mqttFactory = new MqttFactory();

		using var mqttClient = mqttFactory.CreateMqttClient();
		var mqttClientOptions = new MqttClientOptionsBuilder()
			.WithCredentials("rabbitmq", "rabbitmq")
			.WithConnectionUri("tcp://rabbitmq")
			.Build();

		await mqttClient.ConnectAsync(mqttClientOptions);

		var applicationMessage = new MqttApplicationMessageBuilder()
			.WithTopic($"fuel-consumption-{clientId}")
			.WithPayload(message)
			.Build();

		await mqttClient.PublishAsync(applicationMessage);

		await mqttClient.DisconnectAsync();
	}
}