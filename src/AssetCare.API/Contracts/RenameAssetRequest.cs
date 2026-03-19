using System.ComponentModel.DataAnnotations;

namespace AssetCare.API.Contracts;

public class RenameAssetRequest
{
    [Required]
    [StringLength(maximumLength: 500, MinimumLength = 1)]
    public string Name { get; set; } = string.Empty;
}
