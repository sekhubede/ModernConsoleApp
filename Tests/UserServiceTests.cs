using Core.Interfaces;
using Infrastructure.Services;
using Moq;

namespace Tests;

public class UserServiceTests
{
    private readonly Mock<ILoggerService> _loggerMock;
    private readonly IUserService _userService;

    public UserServiceTests()
    {
        _loggerMock = new Mock<ILoggerService>();
        _userService = new UserService(_loggerMock.Object);
    }

    [Fact]
    public void AddUser_ShouldAddUserAndLogInformation()
    {
        // Arrange
        var userName = "John Doe";

        // Act
        _userService.AddUser(userName);

        // Assert
        _loggerMock.Verify(logger => logger.LogInformation(It.Is<string>(s => s.Contains($"User '{userName}' added successfully"))), Times.Once);
    }

    [Fact]
    public void ListUsers_ShouldLogInformaiton()
    {
        // Arrange
        _userService.AddUser("John Doe");
        _userService.AddUser("Jane Smith");

        // Act
        _userService.ListUsers();

        // Assert
        _loggerMock.Verify(logger => logger.LogInformation(It.Is<string>(s => s.Contains("Listing users..."))), Times.Once);
    }
}
