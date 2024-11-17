﻿using System.Text.Json;
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
}
