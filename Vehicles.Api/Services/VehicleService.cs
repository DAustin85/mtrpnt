using System.ComponentModel.DataAnnotations;
using Vehicles.Api.Extensions;
using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;

namespace Vehicles.Api.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehiclesRepository _vehiclesRepository;
    private readonly ILogger<VehicleService> _logger;
    private readonly IVehicleValidationService _vehicleValidationService;
    public VehicleService(IVehiclesRepository vehiclesRepository, ILogger<VehicleService> logger, IVehicleValidationService vehicleValidationService)
    {
        _vehiclesRepository = vehiclesRepository;
        _logger = logger;
        _vehicleValidationService = vehicleValidationService;
    }
    public List<Vehicle> GetAllVehicles()
    {
        return _vehiclesRepository.GetAll();
    }

    public List<Vehicle> GetVehiclesByMarque(string marque)
    {
        return _vehiclesRepository.GetVehiclesByMarque(marque);
    }

    public List<Vehicle> GetVehiclesByModel(string model)
    {
        return _vehiclesRepository.GetVehiclesByModel(model);
    }

    public List<Vehicle> SearchVehicles(VehicleSearchDto vehicle)
    {
        return _vehiclesRepository.SearchVehicles(vehicle);
    }

    public ValidationResult AddVehicle(VehicleDto vehicleRequest)
    {
        var validationResult = _vehicleValidationService.ValidateVehicle(vehicleRequest);

        if (validationResult != ValidationResult.Success)
        {
            return validationResult;
        }

        var vehicle = vehicleRequest.ToVehicleDomainModel();
        _vehiclesRepository.AddVehicle(vehicle);

        return validationResult;
    }
}
