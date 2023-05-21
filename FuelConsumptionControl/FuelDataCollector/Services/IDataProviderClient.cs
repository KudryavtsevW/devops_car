namespace FuelConsumptionControl.Services;

public interface IDataProviderClient
{
	Task SendMessage(object message, int clientId);
}