using System.Runtime.Serialization;

namespace FuelConsumptionControl.Contracts;

public class FuelDataDto
{
	public required int ClientId { get; set; }
	public required double FuelConsumption { get; set; }
	public required double Speed { get; set; }
}