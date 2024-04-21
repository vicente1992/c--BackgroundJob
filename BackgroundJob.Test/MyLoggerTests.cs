using BackgroundJob.Cron.Jobs;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace BackgroundJob.Test;

public class MyLoggerTests
{
    [Fact]
    public async Task LogInformationAsync_ShouldCallLoggerWithCorrectArguments()
    {
        // Arrange
        var loggerMock = Substitute.For<ILogger<MyLogger>>();
        var myLogger = new MyLogger(loggerMock);
        var message = "Test message";
        var args = new object[] { 123, "abc" };

        // Act
        await myLogger.LogInformationAsync(message, args);

        // Assert  
        loggerMock.Received(1).LogInformation(message, args);
        await AssertTaskCompleted();
    }

    private async Task AssertTaskCompleted()
    {
        // Esperar un milisegundo para asegurarse de que Task.CompletedTask se haya completado
        await Task.Delay(1);
        // No se necesita ninguna verificación aquí, simplemente se asegura de que Task.CompletedTask se haya completado
    }

}
