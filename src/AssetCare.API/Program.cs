using System.Text.Json.Serialization;
using AssetCare.Application.Assets;
using AssetCare.Application.Assets.Commands;
using AssetCare.Application.Exceptions;
using AssetCare.Domain.Exceptions;
using AssetCare.Infrastructure.Persistence;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add the database context to be used for database operations
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields =
        HttpLoggingFields.RequestMethod
        | HttpLoggingFields.RequestPath
        | HttpLoggingFields.ResponseStatusCode
        | HttpLoggingFields.Duration;
});

// If anyone asks for the IAssetRepository, give them the AssetRepository from Infrastructure that talks with the database via EF Core.
builder.Services.AddScoped<IAssetRepository, AssetRepository>();
builder.Services.AddScoped<AssetService>();

// Add Swagger for API documentation and testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the API Controllers
builder
    .Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // This will serialize enum values as their string representation instead of numeric values.
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
;

var app = builder.Build();

app.UseHttpLogging();

// Set specific HTTP response codes for custom exceptions.
app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status400BadRequest,
            BusinessRuleException => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };

        await context.Response.WriteAsJsonAsync(new { error = exception?.Message });
    });
});

// Map endpoints to controller actions
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
