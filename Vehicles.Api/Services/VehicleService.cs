using System.ComponentModel.DataAnnotations;
using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;

namespace Vehicles.Api.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehiclesRepository _vehiclesRepository;
    private readonly ILogger<VehicleService> _logger;
    private readonly IVehicleValidationService _vehicleValidationService;
    private readonly IVehicleMapperService _vehicleMapperService;
    public VehicleService(IVehiclesRepository vehiclesRepository, ILogger<VehicleService> logger, IVehicleValidationService vehicleValidationService, IVehicleMapperService vehicleMapperService)
    {
        _vehiclesRepository = vehiclesRepository;
        _logger = logger;
        _vehicleValidationService = vehicleValidationService;
        _vehicleMapperService = vehicleMapperService;
    }
    public List<Vehicle> GetAllVehicles()
    {
        return _vehiclesRepository.GetAll();
    }

    public List<Vehicle> GetVehiclesByMarque(string marque)
    {
        if (string.IsNullOrWhiteSpace(marque))
        {
            throw new ArgumentException("Marque cannot be null or empty");
        }
        return _vehiclesRepository.GetVehiclesByMarque(marque);
    }

    public List<Vehicle> GetVehiclesByModel(string model)
    {
        if (string.IsNullOrWhiteSpace(model))
        {
            throw new ArgumentException("Model cannot be null or empty");
        }
        return _vehiclesRepository.GetVehiclesByModel(model);
    }

    public List<Vehicle> SearchVehicles(VehicleSearchDto vehicle)
    {
        return _vehiclesRepository.SearchVehicles(vehicle);
    }

    public ValidationResult AddVehicle(VehicleDto vehicleRequest)
    {
        var validationResult = _vehicleValidationService.ValidateVehicle(vehicleRequest);

        if (validationResult == ValidationResult.Success)
        {
            var vehicle = _vehicleMapperService.MapToVehicle(vehicleRequest);

            _vehiclesRepository.AddVehicle(vehicle);
        }

        return validationResult;
    }
}
