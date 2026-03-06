# Home Maintenance Manager
Personal project exploring domain-driven design using C# / .NET and EF Core.
Building a maintenance tracking system for household assets and machines.

Tech stack
- C# / .NET 10
- Entity Framework Core
- PostgreSQL
- xUnit


## Development Setup
To run this project locally:

1. Create a .env file in the project root (for Docker Compose) based on .env.example:
```env
POSTGRES_USER=postgres
POSTGRES_PASSWORD=supersecret
POSTGRES_DB=home_maintenance_manager
POSTGRES_HOST=localhost
POSTGRES_PORT=5432
```

2. Set up user secrets in the HomeMaintenanceManager.API project (so the API can connect to the database locally):
```bash
cd src/HomeMaintenanceManager.API

dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=home_maintenance_manager;Username=postgres;Password=supersecret"
```

3. Run the project:
```bash
# Start the PostgreSQL database
docker compose up

# Start the API
dotnet run --project src/HomeMaintenanceManager.API
```