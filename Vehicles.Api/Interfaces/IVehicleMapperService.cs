using Vehicles.Api.Models;

namespace Vehicles.Api.Interfaces;

public interface IVehicleMapperService
{
    public Vehicle MapToVehicle(VehicleDto vehicleDto);
}
