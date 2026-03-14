using AssetCare.Domain.Entities;

namespace AssetCare.Application.Assets.Commands;

public class CreateAsset(IAssetRepository assetRepository)
{
    private readonly IAssetRepository _assetRepository = assetRepository;

    public async Task<Guid> Execute(string name)
    {
        var asset = new Asset(name: name);

        await _assetRepository.AddAsync(asset: asset);
        await _assetRepository.SaveChangesAsync();

        return asset.Id;
    }
}
