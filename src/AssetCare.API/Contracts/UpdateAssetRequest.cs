using System.ComponentModel.DataAnnotations;
using AssetCare.Domain.Entities;

namespace AssetCare.API.Contracts;

public class UpdateAssetRequest
{
    [StringLength(maximumLength: 500, MinimumLength = 1)]
    public string? Name { get; set; } = null;

    public AssetStatus? Status { get; set; } = null;
}
