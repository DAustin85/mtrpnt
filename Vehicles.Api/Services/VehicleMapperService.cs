using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;

namespace Vehicles.Api.Services;

public class VehicleMapperService : IVehicleMapperService
{
    public Vehicle MapToVehicle(VehicleDto vehicleDto)
    {
        return new Vehicle
        {
            Price = vehicleDto.Price,
            Make = vehicleDto.Make,
            Model = vehicleDto.Model,
            Trim = vehicleDto.Trim,
            Colour = vehicleDto.Colour,
            CO2Level = vehicleDto.CO2Level,
            Transmission = vehicleDto.Transmission,
            FuelType = vehicleDto.FuelType,
            EngineSize = vehicleDto.EngineSize,
            DateFirstReg = vehicleDto.DateFirstReg,
            Mileage = vehicleDto.Mileage
        };
    }
}
