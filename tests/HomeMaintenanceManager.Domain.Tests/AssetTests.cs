using HomeMaintenanceManager.Domain.Entities;

namespace HomeMaintenanceManager.Domain.Tests;

public class AssetTests
{
    [Fact]
    public void CreatingAsset_WithValidName()
    {
        const string name = "Dishwasher";

        var asset = new Asset(name: name);

        Assert.Equal(name, asset.Name);
        Assert.NotEqual(Guid.Empty, asset.Id);
    }

    [Fact]
    public void CreatingAsset_WithEmptyName_Throws()
    {
        Assert.Throws<ArgumentException>(() => new Asset(name: ""));
    }

    [Fact]
    public void RenamingAsset_WithEmptyName_Throws()
    {
        var asset = new Asset(name: "Dishwasher");

        Assert.Throws<ArgumentException>(() => asset.Rename(""));
    }
}
