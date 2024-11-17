using Microsoft.AspNetCore.Mvc;
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
    public List<Vehicle> GetAllVehicles()
    {
        return _vehicleService.GetAllVehicles();
    }

    [HttpGet]
    [Route("Marque/{marque}")]
    public List<Vehicle> GetVehiclesByMarque(string marque)
    {
        return _vehicleService.GetVehiclesByMarque(marque);
    }

    [HttpGet]
    [Route("Model/{model}")]
    public List<Vehicle> GetVehiclesByModel(string model)
    {
        return _vehicleService.GetVehiclesByModel(model);
    }
}