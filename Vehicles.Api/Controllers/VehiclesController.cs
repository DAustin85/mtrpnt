using Microsoft.AspNetCore.Mvc;

namespace Vehicles.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly ILogger<VehiclesController> _logger;

    public VehiclesController(ILogger<VehiclesController> logger)
    {
        _logger = logger;
    }
}