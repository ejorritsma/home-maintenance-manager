using AssetCare.Domain.Exceptions;

namespace AssetCare.Domain.Entities;

public enum AssetStatus
{
    Active,
    Inactive,
    Retired,
}

public class Asset(string name)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = ValidateName(name);
    public AssetStatus Status { get; private set; } = AssetStatus.Active;

    public void Rename(string newName)
    {
        if (Status is AssetStatus.Retired)
            throw new BusinessRuleException("Cannot name a retired asset.");

        Name = ValidateName(newName);
    }

    public void ChangeStatus(AssetStatus newStatus)
    {
        Status = newStatus;
    }

    private static string ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ValidationException("Name cannot be empty.");

        return name;
    }
}
