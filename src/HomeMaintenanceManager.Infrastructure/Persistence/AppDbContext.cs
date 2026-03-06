using HomeMaintenanceManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeMaintenanceManager.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Asset> Assets => Set<Asset>();
    public DbSet<MaintenanceTask> MaintenanceTasks => Set<MaintenanceTask>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}
