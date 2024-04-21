using Cronos;

namespace BackgroundJob.Cron.Jobs;

public abstract class CronBackgroundJob(string cronExpression, TimeZoneInfo timeZone) : BackgroundService, IBackgroundJob
{

  private readonly CronExpression _cronExpression = CronExpression.Parse(cronExpression);
  private readonly TimeZoneInfo _timeZone = timeZone;

  protected override async Task ExecuteAsync(CancellationToken stoppingToken)
  {
    var nextOcurrence = GetNextExecutionTime();

    if (nextOcurrence.HasValue)
    {
      var delay = nextOcurrence.Value - DateTimeOffset.UtcNow;
      await Task.Delay(delay, stoppingToken);

      await DoWork(stoppingToken);

      await ExecuteAsync(stoppingToken);

    }
  }

  protected abstract Task DoWork(CancellationToken stoppingToken);

  public DateTimeOffset? GetNextExecutionTime()
  {
    return _cronExpression.GetNextOccurrence(DateTimeOffset.UtcNow, _timeZone);
  }

}
