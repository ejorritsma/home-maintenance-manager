namespace AssetCare.Domain.Entities;

public class MaintenanceTask(string name, TimeSpan frequency)
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Name { get; private set; } = ValidateName(name);

    public TimeSpan Frequency { get; private set; } = ValidateFrequency(frequency);

    public void Rename(string newName)
    {
        Name = ValidateName(newName);
    }

    public void ChangeFrequency(TimeSpan frequency)
    {
        Frequency = ValidateFrequency(frequency);
    }

    private static string ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        return name;
    }

    private static TimeSpan ValidateFrequency(TimeSpan frequency)
    {
        if (frequency <= TimeSpan.Zero)
            throw new ArgumentException("Frequency must be positive", nameof(frequency));

        return frequency;
    }
}
