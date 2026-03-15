using AssetCare.Domain.Entities;

namespace AssetCare.Application.Assets.Commands;

public class AssetService(IAssetRepository assetRepository)
{
    private readonly IAssetRepository _assetRepository = assetRepository;

    public async Task<Guid> Create(string name)
    {
        var asset = new Asset(name: name);

        await _assetRepository.AddAsync(asset: asset);
        await _assetRepository.SaveChangesAsync();

        return asset.Id;
    }

    public async Task<Asset?> GetById(Guid id)
    {
        return await _assetRepository.GetByIdAsync(id);
    }
}
