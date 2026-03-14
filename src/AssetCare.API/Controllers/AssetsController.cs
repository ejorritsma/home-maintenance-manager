namespace AssetCare.API.Controllers;

using AssetCare.API.Contracts;
using AssetCare.Application.Assets.Commands;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/assets")]
public class AssetsController(CreateAsset createAsset) : ControllerBase
{
    private readonly CreateAsset _createAsset = createAsset;

    [HttpPost]
    public async Task<IActionResult> Create(CreateAssetRequest createAssetRequest)
    {
        var id = await _createAsset.Execute(name: createAssetRequest.Name);

        return Created($"/assets/{id}", id);
    }
}
