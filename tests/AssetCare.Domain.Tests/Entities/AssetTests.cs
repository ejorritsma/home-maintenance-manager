using AssetCare.Domain.Entities;
using AssetCare.Domain.Exceptions;

namespace AssetCare.Domain.Tests.Entities;

public class AssetTests
{
    [Fact]
    public void CreatingAsset_WithValidName()
    {
        const string name = "Dishwasher";

        var asset = new Asset(name: name);

        Assert.Equal(name, asset.Name);
        Assert.NotEqual(Guid.Empty, asset.Id);
        Assert.Equal(AssetStatus.Active, asset.Status);
    }

    [Fact]
    public void CreatingAsset_WithEmptyName_Throws()
    {
        Assert.Throws<ValidationException>(() => new Asset(name: ""));
    }

    [Fact]
    public void RenamingAsset_WithEmptyName_Throws()
    {
        var asset = new Asset(name: "Dishwasher");

        Assert.Throws<ValidationException>(() => asset.Rename(""));
    }

    [Fact]
    public void RenamingAsset_WithRetiredStatus_Throws()
    {
        var asset = new Asset(name: "Dishwasher");
        asset.ChangeStatus(AssetStatus.Retired);

        Assert.Throws<BusinessRuleException>(() => asset.Rename("Dishwasher (me)"));
    }
}
