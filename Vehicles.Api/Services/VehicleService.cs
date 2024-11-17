﻿using Vehicles.Api.Interfaces;
using Vehicles.Api.Models;
using Vehicles.Api.Repositories;

namespace Vehicles.Api.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehiclesRepository _vehiclesRepository;
    public VehicleService()
    {
        _vehiclesRepository = new VehiclesRepository();
    }
    public List<Vehicle> GetAllCars()
    {
        return _vehiclesRepository.GetAll();
    }
}