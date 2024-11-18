using System.ComponentModel.DataAnnotations;
using Vehicles.Api.Models;

namespace Vehicles.Api.Interfaces;

public interface IVehicleValidationService
{
    ValidationResult ValidateVehicle(VehicleDto vehicleDto);
}
