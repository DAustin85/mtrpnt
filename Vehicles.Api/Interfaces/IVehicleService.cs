using System.ComponentModel.DataAnnotations;
using Vehicles.Api.Models;

namespace Vehicles.Api.Interfaces;

public interface IVehicleService
{
    List<Vehicle> GetAllVehicles();
    List<Vehicle> GetVehiclesByMarque(string marque);
    List<Vehicle> GetVehiclesByModel(string model);
    List<Vehicle> SearchVehicles(VehicleSearchDto searchVehicle);
    List<ValidationResult> AddVehicle(VehicleDto vehicle);
}
