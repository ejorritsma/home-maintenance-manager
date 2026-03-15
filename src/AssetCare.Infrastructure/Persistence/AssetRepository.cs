using AssetCare.Application.Assets;
using AssetCare.Domain.Entities;

namespace AssetCare.Infrastructure.Persistence;

public class AssetRepository(AppDbContext dbContext) : IAssetRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public async Task AddAsync(Asset asset)
    {
        await _dbContext.Assets.AddAsync(asset);
    }

    public async Task<Asset?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Assets.FindAsync(keyValues: id);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
