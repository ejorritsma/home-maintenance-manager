using AssetCare.Domain.Entities;

namespace AssetCare.Application.Assets;

public interface IAssetRepository
{
    Task AddAsync(Asset asset);
    Task<Asset?> GetByIdAsync(Guid id);
    Task SaveChangesAsync();
}
