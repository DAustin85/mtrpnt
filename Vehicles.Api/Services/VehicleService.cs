using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;
using Vehicles.Api.Repositories;

namespace Vehicles.Api.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehiclesRepository _vehiclesRepository;
    private readonly ILogger<VehicleService> _logger;
    public VehicleService(IVehiclesRepository vehiclesRepository, ILogger<VehicleService> logger)
    {
        _vehiclesRepository = vehiclesRepository;
        _logger = logger;
    }
    public List<Vehicle> GetAllVehicles()
    {
        return _vehiclesRepository.GetAll();
    }

    public List<Vehicle> GetVehiclesByMarque(string marque)
    {
        return _vehiclesRepository.GetVehiclesByMarque(marque);
    }

    public List<Vehicle> GetVehiclesByModel(string model)
    {
        return _vehiclesRepository.GetVehiclesByModel(model);
    }
}
