using HomeMaintenanceManager.Domain.Entities;

namespace HomeMaintenanceManager.Application.Assets.Commands;

public class CreateAsset(IAssetRepository _assetRepository)
{
    private readonly IAssetRepository _assetRepository = _assetRepository;

    public async Task<Guid> Execute(string name)
    {
        var asset = new Asset(name: name);

        await _assetRepository.AddAsync(asset: asset);
        await _assetRepository.SaveChangesAsync();

        return asset.Id;
    }
}
