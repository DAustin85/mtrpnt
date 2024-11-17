using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;

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
        if (string.IsNullOrWhiteSpace(marque))
        {
            throw new ArgumentException("Marque cannot be null or empty");
        }
        return _vehiclesRepository.GetVehiclesByMarque(marque);
    }

    public List<Vehicle> GetVehiclesByModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Model cannot be null or empty");
        }
        return _vehiclesRepository.GetVehiclesByModel(model);
    }

    public List<Vehicle> SearchVehicles(VehicleSearchDto vehicle)
    {
        return _vehiclesRepository.SearchVehicles(vehicle);
    }
}
