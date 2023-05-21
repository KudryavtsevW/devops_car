using System.Runtime.Serialization;

namespace FuelConsumptionControl.Contracts;

[DataContract]
public class FuelConsumptionDto
{
	[DataMember(Name = "fuelConsumption")]
	public required double FuelConsumption { get; set; }
	
	[DataMember(Name = "speed")]
	public required double Speed { get; set; }
}