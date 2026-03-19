namespace AssetCare.Application.Tests.Assets.Commands;

using AssetCare.Application.Assets;
using AssetCare.Application.Assets.Commands;
using AssetCare.Domain.Entities;
using Moq;

public class AssetServiceTest
{
    [Fact]
    public async Task Create_WithValidName_AddsAssetToRepository()
    {
        var repositoryMock = new Mock<IAssetRepository>();
        var assetService = new AssetService(repositoryMock.Object);
        var name = "Washing Machine";

        var id = assetService.Create(name: name);

        repositoryMock.Verify(r => r.AddAsync(It.IsAny<Asset>()), Times.Once);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task Rename_WhenAssetExists_UpdatesNameAndSaves()
    {
        var repositoryMock = new Mock<IAssetRepository>();
        var asset = new Asset("old name");
        repositoryMock.Setup(r => r.GetByIdAsync(asset.Id)).ReturnsAsync(asset);
        var assetService = new AssetService(repositoryMock.Object);

        await assetService.Rename(asset.Id, "new name");

        Assert.Equal("new name", asset.Name);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task Rename_WhenAssetDoesNotExist_Throws()
    {
        var repositoryMock = new Mock<IAssetRepository>();
        var assetService = new AssetService(repositoryMock.Object);

        await Assert.ThrowsAsync<Exception>(() => assetService.Rename(Guid.AllBitsSet, "new name"));
    }
}
