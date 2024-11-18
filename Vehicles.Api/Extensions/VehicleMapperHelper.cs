using Vehicles.Api.Models;

namespace Vehicles.Api.Extensions;

public static class VehicleMapperHelper
{
    public static Vehicle MapFromDto(VehicleDto vehicleDto)
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
