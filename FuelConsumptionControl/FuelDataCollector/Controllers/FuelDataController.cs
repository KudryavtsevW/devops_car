using FuelConsumptionControl.Contracts;
using FuelConsumptionControl.Services;
using Microsoft.AspNetCore.Mvc;

namespace FuelConsumptionControl.Controllers;

[ApiController]
[Route("")]
public class FuelDataController : ControllerBase
{
	private readonly IDataProviderClient _dataProviderClient;

	public FuelDataController(IDataProviderClient dataProviderClient) => _dataProviderClient = dataProviderClient;
	
	[HttpPost]
	[Route("provide-fuel-data")]
	public async Task<IActionResult> ProvideFuelData(FuelDataDto fuelData)
	{
		var fuelConsumptionDto = new FuelConsumptionDto
		{
			FuelConsumption = fuelData.FuelConsumption,
			Speed = fuelData.Speed
		};
		
		await _dataProviderClient.SendMessage(fuelConsumptionDto, fuelData.ClientId);

		return Ok("data successfully provided.");
	}
}