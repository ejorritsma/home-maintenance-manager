namespace AssetCare.API.Controllers;

using AssetCare.API.Contracts;
using AssetCare.Application.Assets.Commands;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/assets")]
public class AssetsController(AssetService assetService) : ControllerBase
{
    private readonly AssetService _assetService = assetService;

    [HttpPost]
    public async Task<IActionResult> Create(CreateAssetRequest createAssetRequest)
    {
        var id = await _assetService.Create(name: createAssetRequest.Name);

        return Created($"/assets/{id}", id);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var asset = await _assetService.GetById(id: id);

        if (asset is null)
            return NotFound();

        var response = new AssetResponse { Id = asset.Id, Name = asset.Name };

        return Ok(response);
    }
}
