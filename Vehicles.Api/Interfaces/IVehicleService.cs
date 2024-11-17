using Vehicles.Api.Models;

namespace Vehicles.Api.Interfaces;

public interface IVehicleService
{
    public List<Vehicle> GetAllCars();
    public List<Vehicle> GetVehiclesByMarque(string marque);
    public List<Vehicle> GetVehiclesByModel(string model);
}
