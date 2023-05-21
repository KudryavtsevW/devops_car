using System.Net.Http.Json;
using Newtonsoft.Json;

namespace CarEmulator;

public class Worker : BackgroundService
{
	private readonly ILogger<Worker> _logger;
	private readonly int _clientId;

	public Worker(ILogger<Worker> logger, int clientId)
	{
		_logger = logger;
		_clientId = clientId;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			await EmulateCar();
			_logger.LogInformation("Worker{id} running at: {time}", _clientId, DateTimeOffset.Now);
			await Task.Delay(300, stoppingToken);
		}
	}

	private async Task EmulateCar()
	{
		var speed = Random.Shared.Next(20, 100);
		var consumption = speed * 0.05 * Random.Shared.Next(4, 7);

		var data = new FuelConsumptionDto
		{
			ClientId = _clientId,
			Speed = speed,
			FuelConsumption = consumption
		};

		var requestMessage = JsonConvert.SerializeObject(data);

		using var client = new HttpClient();


		var result = await client.PostAsJsonAsync("http://fuel-collector/provide-fuel-data", data);
		//var result = await client.PostAsync("http://localhost:5024/provide-fuel-data", JsonContent.Create(requestMessage));
	}
}