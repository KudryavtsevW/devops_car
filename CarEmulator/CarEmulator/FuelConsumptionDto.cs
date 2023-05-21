using System.Runtime.Serialization;

namespace CarEmulator;

[DataContract]
public class FuelConsumptionDto
{
	[DataMember(Name = "clientId")]
	public required int ClientId { get; init; }
	
	[DataMember(Name = "speed")]
	public required double Speed { get; init; }
	
	[DataMember(Name = "fuelConsumption")]
	public required double FuelConsumption { get; init; }
}