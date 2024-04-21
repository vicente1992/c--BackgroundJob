namespace BackgroundJob.Cron.Jobs;

public class Day
{
  public string GetDay(int day = 1)
  {

    return day switch
    {
      1 => "Monday",
      2 => "Tuesday",
      3 => "Wednesday",
      4 => "Thursday",
      5 => "Friday",
      6 => "Saturday",
      7 => "Sunday",
      _ => throw new ArgumentOutOfRangeException(nameof(day), day, "Invalid day of the week.")
    };
  }
}
