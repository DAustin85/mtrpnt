using Microsoft.Extensions.Logging;
using Moq;
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

[SetUp]
    public void Setup()
    {
        _allVehicles = new List<Vehicle>
        {
           _toyota,
           _honda
        };
        _vehiclesRepositoryMock = new Mock<IVehiclesRepository>();
        _vehiclesRepositoryMock.Setup(x => x.GetAll()).Returns(_allVehicles);
        _vehiclesRepositoryMock.Setup(x => x.GetVehiclesByMarque(_honda.Make)).Returns(new List<Vehicle> { _honda });
        _vehiclesRepositoryMock.Setup(x => x.GetVehiclesByMarque(_toyota.Make)).Returns(new List<Vehicle> { _toyota });
        _vehiclesRepositoryMock.Setup(x => x.GetVehiclesByModel(_honda.Model)).Returns(new List<Vehicle> { _honda });
        _vehiclesRepositoryMock.Setup(x => x.GetVehiclesByModel(_toyota.Model)).Returns(new List<Vehicle> { _toyota });
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
        var expected = new List<Vehicle> { _toyota };
        // Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }

    [Test]
    public void GetVehiclesByModel_WhenCalled_ThenReturnsFilteredVehicleList()
    {
        var result = _vehicleService.GetVehiclesByModel(_honda.Model);
        var expected = new List<Vehicle> { _honda };

        // Assert
        Assert.That(result, Is.EquivalentTo(expected));
    }
}
