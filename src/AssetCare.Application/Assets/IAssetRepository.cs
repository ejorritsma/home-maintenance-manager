using AssetCare.Domain.Entities;

namespace AssetCare.Application.Assets;

public interface IAssetRepository
{
    Task AddAsync(Asset asset);
    Task SaveChangesAsync();
}
