namespace AssetCare.Application.Tests.Assets.Commands;

using AssetCare.Application.Assets;
using AssetCare.Application.Assets.Commands;
using AssetCare.Application.Exceptions;
using AssetCare.Domain.Entities;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;

public class AssetServiceTests
{
    private readonly Mock<IAssetRepository> _repoMock;
    private readonly AssetService _service;

    public AssetServiceTests()
    {
        _repoMock = new Mock<IAssetRepository>();
        var logger = NullLogger<AssetService>.Instance;

        _service = new AssetService(_repoMock.Object, logger);
    }

    [Fact]
    public async Task Create_WithValidName_AddsAssetToRepository()
    {
        var name = "Washing Machine";

        var id = _service.Create(name: name);

        _repoMock.Verify(r => r.AddAsync(It.IsAny<Asset>()), Times.Once);
        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task Rename_WhenAssetExists_UpdatesNameAndSaves()
    {
        var asset = new Asset("old name");
        _repoMock.Setup(r => r.GetByIdAsync(asset.Id)).ReturnsAsync(asset);

        await _service.Rename(asset.Id, "new name");

        Assert.Equal("new name", asset.Name);
        _repoMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task Rename_WhenAssetDoesNotExist_Throws()
    {
        await Assert.ThrowsAsync<NotFoundException>(() =>
            _service.Rename(Guid.AllBitsSet, "new name")
        );
    }
}
