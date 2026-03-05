using System.Runtime.InteropServices;
using HomeMaintenanceManager.Domain.Entities;

namespace HomeMaintenanceManager.Domain.Tests;

public class MaintenanceTaskTests
{
    private static MaintenanceTask CreateDefaultTask()
    {
        return new MaintenanceTask(name: "Clean filter", frequency: TimeSpan.FromDays(30));
    }

    [Fact]
    public void Create_SetsNameAndFrequency()
    {
        const string name = "Clean out filter";
        var frequency = TimeSpan.FromDays(30);

        var maintenanceTask = new MaintenanceTask(name: name, frequency: frequency);

        Assert.Equal(name, maintenanceTask.Name);
        Assert.Equal(frequency, maintenanceTask.Frequency);
    }

    [Fact]
    public void Create_WithEmptyName_Throws()
    {
        const string emptyName = "";
        var frequency = TimeSpan.FromDays(30);

        Assert.Throws<ArgumentException>(() =>
            new MaintenanceTask(name: emptyName, frequency: frequency)
        );
    }

    [Fact]
    public void Create_WithZeroFrequency_Throws()
    {
        const string name = "Clean out filter";
        var frequency = TimeSpan.Zero;

        Assert.Throws<ArgumentException>(() =>
            new MaintenanceTask(name: name, frequency: frequency)
        );
    }

    [Fact]
    public void Rename_WithEmptyName_Throws()
    {
        var maintenanceTask = CreateDefaultTask();

        const string emptyName = "";

        Assert.Throws<ArgumentException>(() => maintenanceTask.Rename(newName: emptyName));
    }

    [Fact]
    public void Rename_ChangesName()
    {
        var maintenanceTask = CreateDefaultTask();

        const string newName = "Clean pump filter";

        maintenanceTask.Rename(newName);

        Assert.Equal(newName, maintenanceTask.Name);
    }

    [Fact]
    public void ChangeFrequency_ChangesFrequency()
    {
        var maintenanceTask = CreateDefaultTask();

        var newFrequency = TimeSpan.FromDays(60);

        maintenanceTask.ChangeFrequency(newFrequency);

        Assert.Equal(newFrequency, maintenanceTask.Frequency);
    }

    [Fact]
    public void ChangeFrequency_WithZeroFrequency_Throws()
    {
        var maintenanceTask = CreateDefaultTask();

        Assert.Throws<ArgumentException>(() => maintenanceTask.ChangeFrequency(TimeSpan.Zero));
    }
}
