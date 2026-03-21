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

    public async Task Rename(Guid id, string newName)
    {
        var asset =
            await _assetRepository.GetByIdAsync(id)
            ?? throw new Exception($"Asset with ID {id} not found.");

        asset.Rename(newName: newName);

        await _assetRepository.SaveChangesAsync();
    }

    public async Task ChangeStatus(Guid id, AssetStatus newStatus)
    {
        var asset =
            await _assetRepository.GetByIdAsync(id)
            ?? throw new Exception($"Asset with ID {id} not found.");

        asset.ChangeStatus(newStatus: newStatus);

        await _assetRepository.SaveChangesAsync();
    }

    public async Task<Asset?> GetById(Guid id)
    {
        return await _assetRepository.GetByIdAsync(id);
    }
}
