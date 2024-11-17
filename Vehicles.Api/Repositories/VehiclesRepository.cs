using System.Text.Json;
using Vehicles.Api.Models;
using Vehicles.Api.Interfaces;

namespace Vehicles.Api.Repositories;

public class VehiclesRepository : IVehiclesRepository
{
    List<Vehicle> _vehicles;
    public VehiclesRepository()
    {
        using (StreamReader r = new StreamReader("Repositories/vehicles.json"))
        {
            string json = r.ReadToEnd();
            _vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();
        }
    }

    public List<Vehicle> GetAll()
    {
        return _vehicles;
    }

    public List<Vehicle> GetVehiclesByMarque(string marque)
    {
        return _vehicles.Where(vehicle => 
            marque.Equals(vehicle.Make, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Vehicle> GetVehiclesByModel(string model)
    {
        return _vehicles.Where(vehicle =>
            model.Equals(vehicle.Model, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public List<Vehicle> SearchVehicles(VehicleSearchDto searchModel)
    {
        var results = new List<Vehicle>();
        var searchProperties = typeof(VehicleSearchDto).GetProperties().Where(property => property.GetValue(searchModel) is not null);
        var vehicleProperties = typeof(Vehicle).GetProperties();

        foreach (var vehicle in _vehicles)
        {
            results.Add(vehicle);
            foreach (var searchProperty in searchProperties)
            {
                var propVal = searchProperty.GetValue(searchModel);
                var vehiclePropVal = vehicleProperties.Single(vehicleProperty =>
                    vehicleProperty.Name.Equals(searchProperty.Name)).GetValue(vehicle);

                if (PropertyValueEqualsSearchValue(propVal, vehiclePropVal))
                {
                    continue;
                }

                results.Remove(vehicle);
                break;
            }
        }

        return results;
    }

    public void AddVehicle(Vehicle vehicle)
    {
        _vehicles.Add(vehicle);
    }

    private static bool PropertyValueEqualsSearchValue(object? propVal, object? vehiclePropVal)
    {
        return (propVal is string _propValString && _propValString.Equals(vehiclePropVal!.ToString(), StringComparison.OrdinalIgnoreCase)) || propVal!.Equals(vehiclePropVal);
    }
}
