using AssetCare.Domain.Entities;

namespace AssetCare.API.Contracts;

public class AssetResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required AssetStatus Status { get; init; }
}
