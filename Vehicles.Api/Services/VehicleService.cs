using System.ComponentModel.DataAnnotations;
using Vehicles.Api.Extensions;
using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;

namespace Vehicles.Api.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehiclesRepository _vehiclesRepository;
    private readonly ILogger<VehicleService> _logger;
    public VehicleService(IVehiclesRepository vehiclesRepository, ILogger<VehicleService> logger)
    {
        _vehiclesRepository = vehiclesRepository;
        _logger = logger;
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

    public List<ValidationResult> AddVehicle(VehicleDto vehicleRequest)
    {
        var validationContext = new ValidationContext(vehicleRequest, null, null);
        var validationResults = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(vehicleRequest, validationContext, validationResults, true);

        if (!isValid)
        {
            return validationResults;
        }

        _vehiclesRepository.AddVehicle(vehicleRequest.ToVehicleDomainModel());

        return validationResults;
    }
}
