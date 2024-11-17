using Vehicles.Api.Models;

namespace Vehicles.Api.Interfaces;

public interface IVehiclesRepository
{
    public List<Vehicle> GetAll();
    public List<Vehicle> GetVehiclesByMarque(string marque);
}
