using System.Reflection;
using BackgroundJob.Cron;
using BackgroundJob.Cron.Jobs;
using Moq;

namespace BackgroundJob.Test;

public class MySchedulerJobTests
{
  [Fact]
  public async Task DoWork_LogsInformation()
  {
    // Arrange  
    var mockLogger = new Mock<IMyLogger>();
    var job = new MySchedulerJob(new CronSettings<MySchedulerJob>
    {
      CronExpression = "* * * * *",
      TimeZone = TimeZoneInfo.Utc
    }, mockLogger.Object);

    // Act 
    await Generic.InvokeMethodAsync(job, "DoWork");

    // Assert
    mockLogger.Verify(
        x => x.LogInformationAsync(
            It.Is<string>(expectedMessage => expectedMessage.Contains("Running... at")),
            It.IsAny<object[]>()
        ),
        Times.Once
    );
  }

}
