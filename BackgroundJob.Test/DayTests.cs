
using BackgroundJob.Cron.Jobs;

namespace BackgroundJob.Test;

public class DayTests
{
  [Fact]
  public void GetDay_DefaultValue_ReturnsMonday()
  {
    // Arrange
    var day = new Day();

    // Act
    var result = day.GetDay();

    // Assert
    Assert.Equal("Monday", result);
  }

  [Theory]
  [InlineData(1, "Monday")]
  [InlineData(2, "Tuesday")]
  [InlineData(3, "Wednesday")]
  [InlineData(4, "Thursday")]
  [InlineData(5, "Friday")]
  [InlineData(6, "Saturday")]
  [InlineData(7, "Sunday")]
  public void GetDay_ValidInput_ReturnsCorrectDay(int input, string expected)
  {
    // Arrange
    var day = new Day();

    // Act
    var result = day.GetDay(input);

    // Assert
    Assert.Equal(expected, result);
  }

  [Fact]
  public void GetDay_InvalidDay_ThrowsExceptionWithCorrectMessage()
  {
    // Arrange
    var day = new Day();

    // Act
    var exception = Assert.Throws<ArgumentOutOfRangeException>(() => day.GetDay(8));

    // Assert
    Assert.Contains("Invalid day of the week.", exception.Message);
  }
}
