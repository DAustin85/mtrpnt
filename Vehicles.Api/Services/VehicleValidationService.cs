using System.ComponentModel.DataAnnotations;
using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;

namespace Vehicles.Api.Services;

public class VehicleValidationService : IVehicleValidationService
{
    private readonly ILogger<VehicleValidationService> _logger;

    public VehicleValidationService(ILogger<VehicleValidationService> logger)
    {
        _logger = logger;
    }

    public ValidationResult ValidateVehicle(VehicleDto vehicleDto)
    {
        if (vehicleDto is null)
        {
            _logger.LogError("VehicleDto is null");
            return new ValidationResult("VehicleDto is null");
        }

        if (string.IsNullOrWhiteSpace(vehicleDto.Make))
        {
            _logger.LogError("Make cannot be null or empty");
            return new ValidationResult("Make cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(vehicleDto.Model))
        {
            _logger.LogError("Model cannot be null or empty");
            return new ValidationResult("Model cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(vehicleDto.Trim))
        {
            _logger.LogError("Trim cannot be null or empty");
            return new ValidationResult("Trim cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(vehicleDto.Colour))
        {
            _logger.LogError("Colour cannot be null or empty");
            return new ValidationResult("Colour cannot be null or empty");
        }

        if (vehicleDto.CO2Level < 0)
        {
            _logger.LogError("CO2Level cannot be less than 0");
            return new ValidationResult("CO2Level cannot be less than 0");
        }

        if (string.IsNullOrWhiteSpace(vehicleDto.Transmission))
        {
            _logger.LogError("Transmission cannot be null or empty");
            return new ValidationResult("Transmission cannot be null or empty");
        }

        if (string.IsNullOrWhiteSpace(vehicleDto.FuelType))
        {
            _logger.LogError("FuelType cannot be null or empty");
            return new ValidationResult("FuelType cannot be null or empty");
        }

        if (vehicleDto.EngineSize < 0)
        {
            _logger.LogError("EngineSize cannot be less than 0");
            return new ValidationResult("EngineSize cannot be less than 0");
        }

        if (!DateTime.TryParse(vehicleDto.DateFirstReg, out var _dateFirstReg))
        {
            _logger.LogError("DateFirstReg is not a valid date");
            return new ValidationResult("DateFirstReg cannot be in the future");
        }

        if (vehicleDto.Mileage < 0)
        {
            _logger.LogError("Mileage cannot be less than 0");
            return new ValidationResult("Mileage cannot be less than 0");
        }

        return ValidationResult.Success!;
    }
}
