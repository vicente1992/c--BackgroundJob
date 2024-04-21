namespace BackgroundJob.Cron.Jobs;

public class MySchedulerJob(CronSettings<MySchedulerJob> settings, IMyLogger logger)
                           : CronBackgroundJob(settings.CronExpression, settings.TimeZone)
{

  private readonly IMyLogger _logger = logger;
  protected override Task DoWork(CancellationToken stoppingToken)
  {

    _logger.LogInformationAsync("🚀🚀🚀 Running... at {0} 🚀🚀🚀", DateTime.UtcNow);
    return Task.CompletedTask;

  }

}
