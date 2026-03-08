using HomeMaintenanceManager.API.Contracts;
using HomeMaintenanceManager.Application.Assets;
using HomeMaintenanceManager.Application.Assets.Commands;
using HomeMaintenanceManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// If anyone asks for the IAssetRepository, give them the AssetRepository from Infrastructure that talks with the database via EF Core.
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<CreateAsset>();

var app = builder.Build();

app.MapPost(
    "/assets",
    async (CreateAssetRequest request, CreateAsset createAsset) =>
    {
        var id = await createAsset.Execute(name: request.Name);

        return Results.Created($"/assets/{id}", id);
    }
);

app.Run();
