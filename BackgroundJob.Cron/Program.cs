using BackgroundJob.Cron;
using BackgroundJob.Cron.Jobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMyLogger, MyLogger>();
builder.Services.AddCronJob<MySchedulerJob>(options =>
{
  options.CronExpression = "*/1 * * * *";
  options.TimeZone = TimeZoneInfo.Local;
});

var app = builder.Build();

app.Run();
