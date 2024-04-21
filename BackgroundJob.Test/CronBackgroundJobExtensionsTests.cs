using BackgroundJob.Cron.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace BackgroundJob.Test;

public class CronBackgroundJobExtensionsTests
{
  [Fact]
  public void AddCronJob_ThrowsArgumentNullException_WhenOptionsIsNull()
  {
    // Arrange
    var services = new ServiceCollection();

    // Act & Assert
    Assert.Throws<ArgumentNullException>(() => services.AddCronJob<MySchedulerJob>(null));

  }

  [Fact]
  public void AddCronJob_ThrowsArgumentNullException_WhenCronExpressionIsNullOrWhitespace()
  {
    // Arrange
    var services = new ServiceCollection();

    // Act & Assert
    Assert.Throws<ArgumentNullException>(() => services.AddCronJob<MySchedulerJob>(config =>
    {
      config.CronExpression = "";
    }));
  }

  [Fact]
  public void AddCronJob_AddsServiceAndHostedService()
  {
    // Arrange
    var services = new ServiceCollection();
    var cronSettings = new CronSettings<MySchedulerJob>
    {
      CronExpression = "*/5 * * * *",
    };

    // Act
    services.AddCronJob<MySchedulerJob>(config =>
    {
      config.CronExpression = cronSettings.CronExpression;
    });

    // Assert
    var serviceProvider = services.BuildServiceProvider();
    var resolvedSettings = serviceProvider.GetService<CronSettings<MySchedulerJob>>();
    Assert.NotNull(resolvedSettings);
    Assert.Equal(cronSettings.CronExpression, resolvedSettings.CronExpression);

  }
}
