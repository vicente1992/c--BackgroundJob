namespace BackgroundJob.Cron;

public interface IMyLogger
{
  Task LogInformationAsync(string message, params object[] args);
}
