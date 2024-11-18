using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Vehicles.Api.Models;

public class VehicleDto
{
    [JsonPropertyName("price")]
    [Required]
    public int Price { get; set; }
    [JsonPropertyName("make")]
    [Required]
    [StringLength(50)]
    public string Make { get; set; }
    [JsonPropertyName("model")]
    [Required]
    [StringLength(50)]
    public string Model { get; set; }
    [JsonPropertyName("trim")]
    [Required]
    [StringLength(50)]
    public string Trim { get; set; }
    [JsonPropertyName("colour")]
    [Required]
    [StringLength(50)]
    public string Colour { get; set; }
    [JsonPropertyName("co2_level")]
    [Required]
    [Range(0, int.MaxValue)]
    public int CO2Level { get; set; }
    [JsonPropertyName("transmission")]
    [Required]
    [StringLength(32)]
    public string Transmission { get; set; }
    [JsonPropertyName("fuel_type")]
    [Required]
    [StringLength(32)]
    public string FuelType { get; set; }
    [JsonPropertyName("engine_size")]
    [Required]
    [Range(0, 64000)]
    public int EngineSize { get; set; }
    [JsonPropertyName("date_first_reg")]
    [Required]
    [StringLength(50)]
    public string DateFirstReg { get; set; }
    [JsonPropertyName("mileage")]
    [Required]
    [Range(0, int.MaxValue)]
    public int Mileage { get; set; }
}
