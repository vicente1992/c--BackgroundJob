
namespace BackgroundJob.Cron.Jobs;

public class MyLogger(ILogger<MyLogger> logger) : IMyLogger
{
  private readonly ILogger<MyLogger> _logger = logger;

  public async Task LogInformationAsync(string message, params object[] args)
  {
    _logger.LogInformation(message, args);
    await Task.CompletedTask;
  }

}
