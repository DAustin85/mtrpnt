using Vehicles.Api.Models;

namespace Vehicles.Api.Interfaces;

public interface IVehicleService
{
    public List<Vehicle> GetAllCars();
}
