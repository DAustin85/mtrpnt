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
    public List<Vehicle> GetAllCars()
    {
        return _vehicleService.GetAllCars();
    }

    [HttpGet]
    [Route("Marque/{marque}")]
    public List<Vehicle> GetAllCars(string marque)
    {
        return _vehicleService.GetVehiclesByMarque(marque);
    }
}