using Moq;
using BackgroundJob.Cron.Jobs;
namespace BackgroundJob.Test;

public class UnitTest1
{
    [Fact]

    public void GetDay_ReturnsCorrectDay()
    {
        // Arrange
        var mySchedulerJob = new Day();

        // Act
        var result = mySchedulerJob.GetDay(1);

        // Assert
        Assert.Equal("Monday", result);
    }
}