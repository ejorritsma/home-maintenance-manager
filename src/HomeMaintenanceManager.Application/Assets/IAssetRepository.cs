using HomeMaintenanceManager.Domain.Entities;

namespace HomeMaintenanceManager.Application.Assets;

public interface IAssetRepository
{
    Task AddAsync(Asset asset);
    Task SaveChangesAsync();
}
