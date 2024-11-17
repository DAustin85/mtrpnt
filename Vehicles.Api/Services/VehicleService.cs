using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;
using Vehicles.Api.Repositories;

namespace Vehicles.Api.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehiclesRepository _vehiclesRepository;
    public VehicleService()
    {
        _vehiclesRepository = new VehiclesRepository();
    }
    public List<Vehicle> GetAllCars()
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
