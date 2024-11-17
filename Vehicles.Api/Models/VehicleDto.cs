﻿using System.Text.Json.Serialization;

namespace Vehicles.Api.Models;

public class VehicleDto
{
    [JsonPropertyName("price")]
    public int Price { get; set; }
    [JsonPropertyName("make")]
    public string Make { get; set; }
    [JsonPropertyName("model")]
    public string Model { get; set; }
    [JsonPropertyName("trim")]
    public string Trim { get; set; }
    [JsonPropertyName("colour")]
    public string Colour { get; set; }
    [JsonPropertyName("co2_level")]
    public int CO2Level { get; set; }
    [JsonPropertyName("transmission")]
    public string Transmission { get; set; }
    [JsonPropertyName("fuel_type")]
    public string FuelType { get; set; }
    [JsonPropertyName("engine_size")]
    public int EngineSize { get; set; }
    [JsonPropertyName("date_first_reg")]
    public string DateFirstReg { get; set; }
    [JsonPropertyName("mileage")]
    public int Mileage { get; set; }
}