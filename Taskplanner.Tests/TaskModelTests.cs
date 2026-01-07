using Taskplanner.Models;
using Xunit;

namespace Taskplanner.Tests;

public class TaskModelTests
{
    [Fact]
    public void IsValid_ReturnsFalse_WhenTitleIsNullOrWhitespace()
    {
        var t1 = new TaskModel { Title = null };
        var t2 = new TaskModel { Title = "" };
        var t3 = new TaskModel { Title = "   " };
        var t4 = new TaskModel { Title = "Handla mjölk" };

        Assert.False(t1.IsValid());
        Assert.False(t2.IsValid());
        Assert.False(t3.IsValid());
        Assert.True(t4.IsValid());
    }

    [Fact]
    public void IsCompleted_CanBeSet_AndReadBack()
    {
        var task = new TaskModel { Title = "Test" };

        task.IsCompleted = true;

        Assert.True(task.IsCompleted);
    }
}

