using Core.Interfaces;
using Infrastructure.Services;
using Moq;
using Serilog;

namespace Tests;

public class LoggerServiceTests
{
    private readonly Mock<ILogger> _serilogMock;
    private readonly ILoggerService _loggerService;

    public LoggerServiceTests()
    {
        _serilogMock = new Mock<ILogger>();
        _loggerService = new LoggerService(_serilogMock.Object);
    }

    [Fact]
    public void LogInformation_ShouldCallSerilogInformation()
    {
        // Arrange
        var message = "This is an info log";

        // Act
        _loggerService.LogInformation(message);

        // Assert
        _serilogMock.Verify(logger => logger.Information(It.Is<string>(s => s.Contains(message))), Times.Once);
    }
}
