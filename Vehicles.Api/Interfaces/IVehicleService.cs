using Vehicles.Api.Models;

namespace Vehicles.Api.Interfaces;

public interface IVehicleService
{
    public List<Vehicle> GetAllVehicles();
    public List<Vehicle> GetVehiclesByMarque(string marque);
    public List<Vehicle> GetVehiclesByModel(string model);
    public List<Vehicle> SearchVehicles(VehicleSearchDto searchVehicle);
}
