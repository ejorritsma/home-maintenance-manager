using AssetCare.Application.Exceptions;
using AssetCare.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace AssetCare.Application.Assets.Commands;

public class AssetService(IAssetRepository assetRepository, ILogger<AssetService> logger)
{
    private readonly IAssetRepository _assetRepository = assetRepository;
    private readonly ILogger<AssetService> _logger = logger;

    public async Task<Guid> Create(string name)
    {
        _logger.LogInformation("Creating asset {AssetName}", name);
        var asset = new Asset(name: name);

        await _assetRepository.AddAsync(asset: asset);
        await _assetRepository.SaveChangesAsync();

        return asset.Id;
    }

    public async Task Rename(Guid id, string newName)
    {
        _logger.LogInformation("Renaming asset {AssetId} to {NewName}", id, newName);
        var asset =
            await _assetRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Asset with ID {id} not found.");

        asset.Rename(newName: newName);

        await _assetRepository.SaveChangesAsync();
    }

    public async Task ChangeStatus(Guid id, AssetStatus newStatus)
    {
        _logger.LogInformation("Change status of asset {AssetId} to {NewStatus}", id, newStatus);
        var asset =
            await _assetRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Asset with ID {id} not found.");

        asset.ChangeStatus(newStatus: newStatus);

        await _assetRepository.SaveChangesAsync();
    }

    public async Task<Asset?> GetById(Guid id)
    {
        return await _assetRepository.GetByIdAsync(id);
    }
}
