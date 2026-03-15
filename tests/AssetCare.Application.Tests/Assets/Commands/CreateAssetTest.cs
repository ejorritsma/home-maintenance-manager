namespace AssetCare.Application.Tests.Assets.Commands;

using AssetCare.Application.Assets;
using AssetCare.Application.Assets.Commands;
using AssetCare.Domain.Entities;
using Moq;

public class CreateAssetTest
{
    [Fact]
    public async Task Execute_WithValidName_AddsAssetToRepository()
    {
        var repositoryMock = new Mock<IAssetRepository>();
        var command = new AssetService(repositoryMock.Object);
        var name = "Washing Machine";

        var id = command.Create(name: name);

        repositoryMock.Verify(r => r.AddAsync(It.IsAny<Asset>()), Times.Once);
        repositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
    }
}
