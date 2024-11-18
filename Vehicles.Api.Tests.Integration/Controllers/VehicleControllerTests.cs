using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text;
using System.Text.Json;
using Vehicles.Api.Models;

namespace Vehicles.Api.Tests.Integration.Controllers;

public class VehicleControllerTests : WebApplicationFactory<Program>
{
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _client = CreateClient();
    }

    [Test]
    public async Task GetAllVehicles_WhenOneOrMoreResults_ReturnsOkResponse()
    {
        var response = await _client.GetAsync("/vehicles/all");

        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task GetVehiclesByMarque_WhenOneOrMoreResults_ReturnsOkResponse()
    {
        var response = await _client.GetAsync("/Vehicles/Marque/Land Rover");

        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task GetVehiclesByMarque_WhenNoResults_ReturnsNoContentResponse()
    {
        var response = await _client.GetAsync("/vehicles/marque/Powell Motors");

        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
    }

    [Test]
    public async Task GetVehiclesByModel_WhenOneOrMoreResults_ReturnsOkResponse()
    {
        var response = await _client.GetAsync("/vehicles/model/Fiesta");

        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task GetVehiclesByModel_WhenNoResults_ReturnsNoContentResponse()
    {
        var response = await _client.GetAsync("/vehicles/model/NotARealModel");

        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
    }

    [Test]
    public async Task SearchVehicles_WhenOneOrMoreResults_ReturnsOkResponse()
    {
        var searchrequest = new VehicleSearchDto { Make = "Ford", Model = "Fiesta" };
        var json = new StringContent(JsonSerializer.Serialize(searchrequest), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/vehicles/Search", json);

        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
    }

    [Test]
    public async Task SearchVehicles_WhenNoResults_ReturnsNoContentResponse()
    {
        var searchrequest = new VehicleSearchDto { Make = "Powell Motors", Model = "The Homer" };
        var json = new StringContent(JsonSerializer.Serialize(searchrequest), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync("/vehicles/Search", json);

        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
    }

    [Test]
    public async Task AddVehicle_WhenSuccessful_ReturnsNoContentResponse()
    {
        var putRequest = new VehicleDto {
            Price = 10000,
            Make = "Powell Motors",
            Model = "The Homer",
            Trim = "Sedan",
            Colour = "Pink",
            CO2Level = 100,
            Transmission = "Automatic",
            FuelType = "Petrol",
            EngineSize = 3000,
            DateFirstReg = "01/01/1999",
            Mileage = 1000
        };
        var test = JsonSerializer.Serialize(putRequest);
        var json = new StringContent(test, Encoding.UTF8, "application/json");
        var response = await _client.PutAsync("/Vehicles/Add", json);

        response.EnsureSuccessStatusCode();
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
    }

    [Test]
    public async Task AddVehicle_WhenInvalidModel_ReturnsBadRequestResponse()
    {
        var response = await _client.PutAsync("/vehicles/Add", new StringContent("", Encoding.UTF8, "application/json"));

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
    }

}
