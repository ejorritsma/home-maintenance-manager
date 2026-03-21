using AssetCare.Domain.Entities;

namespace AssetCare.API.Contracts;

public class AssetResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public AssetStatus Status { get; init; } = AssetStatus.Active;
}
