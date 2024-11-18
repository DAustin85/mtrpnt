using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;

namespace Vehicles.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly ILogger<VehiclesController> _logger;
    private readonly IVehicleService _vehicleService;

    public VehiclesController(IVehicleService vehicleService, ILogger<VehiclesController> logger)
    {
        _logger = logger;
        _vehicleService = vehicleService;
    }

    [HttpGet]
    [Route("All")]
    [ProducesResponseType(typeof(List<Vehicle>), 200)]
    [ProducesResponseType(204)]
    public IActionResult GetAllVehicles()
    {
        var allVehicles = _vehicleService.GetAllVehicles();
        return allVehicles.Any()
            ? Ok(allVehicles)
            : NoContent();
    }

    [HttpGet]
    [Route("Marque/{marque}")]
    [ProducesResponseType(typeof(List<Vehicle>), 200)]
    [ProducesResponseType(204)]
    public IActionResult GetVehiclesByMarque(string marque)
    {
        var results = _vehicleService.GetVehiclesByMarque(marque);
        return results.Any()
            ? Ok(results)
            : NoContent();
    }

    [HttpGet]
    [Route("Model/{model}")]
    [ProducesResponseType(typeof(List<Vehicle>), 200)]
    [ProducesResponseType(204)]
    public IActionResult GetVehiclesByModel(string model)
    {
        var results = _vehicleService.GetVehiclesByModel(model);
        return results.Any()
            ? Ok(results)
            : NoContent();
    }

    [HttpPost]
    [Route("Search")]
    [ProducesResponseType(typeof(List<Vehicle>), 200)]
    [ProducesResponseType(204)]
    public IActionResult GetVehiclesByModel([FromBody] VehicleSearchDto searchVehicle)
    {
        var results = _vehicleService.SearchVehicles(searchVehicle);
        return results.Any()
            ? Ok(results)
            : NoContent();
    }

    [HttpPut]
    [Route("AddVehicle")]
    [ProducesResponseType(typeof(ValidationResult), 200)]
    [ProducesResponseType(typeof(ValidationResult), 400)]
    public IActionResult AddVehicle([FromBody] VehicleDto vehicleRequest)
    {
        var result = _vehicleService.AddVehicle(vehicleRequest);
        return result ==  ValidationResult.Success
            ? Ok(result)
            : BadRequest(result);

    }
}