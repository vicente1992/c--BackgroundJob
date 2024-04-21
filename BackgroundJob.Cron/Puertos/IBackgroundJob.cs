namespace BackgroundJob.Cron;

public interface IBackgroundJob
{

  DateTimeOffset? GetNextExecutionTime();

}
