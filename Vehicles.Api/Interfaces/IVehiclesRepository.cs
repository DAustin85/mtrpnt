using Vehicles.Api.Models;

namespace Vehicles.Api.Interfaces;

public interface IVehiclesRepository
{
    List<Vehicle> GetAll();
    List<Vehicle> GetVehiclesByMarque(string marque);
    List<Vehicle> GetVehiclesByModel(string model);
    List<Vehicle> SearchVehicles(VehicleSearchDto vehicle);
    void AddVehicle(Vehicle vehicle);
}
