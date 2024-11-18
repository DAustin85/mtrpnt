using Vehicles.Api.Interfaces;
using Vehicles.Api.Repositories;
using Vehicles.Api.Services;

namespace Vehicles.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddSingleton<IVehiclesRepository, VehiclesRepository>();
        builder.Services.AddSingleton<IVehicleService, VehicleService>();

        var app = builder.Build();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}


