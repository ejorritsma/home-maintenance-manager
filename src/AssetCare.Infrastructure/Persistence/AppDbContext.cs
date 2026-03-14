using AssetCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssetCare.Infrastructure.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<MaintenanceTask> MaintenanceTasks => Set<MaintenanceTask>();
}
