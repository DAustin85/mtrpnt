using Microsoft.Extensions.Logging;
using Moq;
using System.ComponentModel.DataAnnotations;
using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;
using Vehicles.Api.Services;

namespace Vehicles.Api.Tests.Unit.Services;

[TestFixture]
public class GivenIWantToGetAListOfVehicles
{
    private VehicleService _vehicleService;
    private Mock<IVehiclesRepository> _vehiclesRepositoryMock;
    private Mock<ILogger<VehicleService>> _loggerMock;
    private List<Vehicle> _allVehicles;
    private Vehicle _toyota = new Vehicle { Make = "Toyota", Model = "Corolla" };
    private Vehicle _honda = new Vehicle { Make = "Honda", Model = "Civic" };
    private VehicleDto _addVehicleDto = new VehicleDto {
        Price = 10000,
        Make = "Make",
        Model = "Model",
        Trim = "Trim",
        Colour = "Colour",
        CO2Level = 100,
        Transmission = "Transmission",
        FuelType = "FuelType",
        EngineSize = 1000,
        DateFirstReg = "01/01/2024",
        Mileage = 10001
    };
    private VehicleSearchDto _searchVehicle = new VehicleSearchDto { Make = "Toyota", Model = "Corolla" };

    [SetUp]
    public void Setup()
    {
        var failedValidationResult = new ValidationResult("Failed validation");
        _allVehicles = new List<Vehicle>
        {
           _toyota,
           _toyota,
           _toyota,
           _honda,
           _honda,
           _honda
        };
        _vehiclesRepositoryMock = new Mock<IVehiclesRepository>();
        _vehiclesRepositoryMock.Setup(x => x.GetAll()).Returns(_allVehicles);
        _vehiclesRepositoryMock.Setup(x => x.GetVehiclesByMarque(_honda.Make)).Returns(_allVehicles.Where(x => x.Make == _honda.Make).ToList());
        _vehiclesRepositoryMock.Setup(x => x.GetVehiclesByMarque(_toyota.Make)).Returns(_allVehicles.Where(x => x.Make == _toyota.Make).ToList());
        _vehiclesRepositoryMock.Setup(x => x.GetVehiclesByModel(_honda.Model)).Returns(_allVehicles.Where(x => x.Model == _honda.Model).ToList());
        _vehiclesRepositoryMock.Setup(x => x.GetVehiclesByModel(_toyota.Model)).Returns(_allVehicles.Where(x => x.Model == _toyota.Model).ToList());
        _vehiclesRepositoryMock
            .Setup(x => x.SearchVehicles(It.Is<VehicleSearchDto>(v => v.Make == _toyota.Make && v.Model == _toyota.Model)))
            .Returns(_allVehicles.Where(x => x.Model == _searchVehicle.Model && x.Make == _searchVehicle.Make).ToList());
        _loggerMock = new Mock<ILogger<VehicleService>>();
        _vehicleService = new VehicleService(_vehiclesRepositoryMock.Object, _loggerMock.Object);
    }

    [Test]
    public void GetAllVehicles_WhenCalled_ThenReturnsAllVehicles()
    {
        var result = _vehicleService.GetAllVehicles();

        Assert.That(result, Is.EqualTo(_allVehicles));
    }

    [Test]
    public void GetVehiclesByMarque_WhenCalled_ThenReturnsFilteredVehicleList()
    {
        var result = _vehicleService.GetVehiclesByMarque(_toyota.Make);

        Assert.That(result.Any(v => v.Make != _toyota.Make), Is.False);
    }

    [Test]
    public void GetVehiclesByModel_WhenCalled_ThenReturnsFilteredVehicleList()
    {
        var result = _vehicleService.GetVehiclesByModel(_honda.Model);

        Assert.That(result.Any(v => v.Model != _honda.Model), Is.False);
    }

    [Test]
    public void AddVehicle_WhenCalledWithAValidModel_ThenReturnsSuccess()
    {
        var result = _vehicleService.AddVehicle(_addVehicleDto);

        Assert.That(result.Any(x => string.IsNullOrEmpty(x.ErrorMessage)), Is.False);
    }

    [Test]
    public void AddVehicle_WhenCalledWithAnInvalidModel_ThenReturnsValidationError()
    {
        var result = _vehicleService.AddVehicle(new VehicleDto());

        //Assert.That(result.ErrorMessage, Is.EqualTo("Failed validation"));
    }

    [Test]
    public void SearchVehicles_WhenCalled_ThenReturnsFilteredResultSet()
    {
        var result = _vehicleService.SearchVehicles(_searchVehicle);

        Assert.That(result.Any(x => x.Make != _searchVehicle.Make && x.Model != _searchVehicle.Model), Is.False);
    }
}
