using Xunit;
using FiniteStateMachine.Core;

namespace FiniteStateMachine.Tests;

public class ModThreeTests
{
    [Theory]
    [InlineData("1101", 1)]  // 13 % 3 = 1
    [InlineData("1110", 2)]  // 14 % 3 = 2
    [InlineData("1111", 0)]  // 15 % 3 = 0
    [InlineData("0", 0)]     // 0 % 3 = 0
    [InlineData("1", 1)]     // 1 % 3 = 1
    [InlineData("10", 2)]    // 2 % 3 = 2
    [InlineData("1010", 1)]  // 10 % 3 = 1
    public void ModThreeFSM_ProcessesInputCorrectly(string input, int expectedRemainder)
    {
        // Arrange
        var fsm = new FiniteStateMachine<char, int>(ModThreeState.S0);

        // Act
        var result = fsm.ProcessInputs(input);

        // Assert
        Assert.Equal(expectedRemainder, result);
    }

    [Fact]
    public void ModThreeFSM_HandlesEmptyInput()
    {
        // Arrange
        var fsm = new FiniteStateMachine<char, int>(ModThreeState.S0);

        // Act
        var result = fsm.ProcessInputs(string.Empty);

        // Assert
        Assert.Equal(0, result); // Empty input should return remainder 0
    }

    [Fact]
    public void ModThreeFSM_ThrowsOnInvalidInput()
    {
        // Arrange
        var fsm = new FiniteStateMachine<char, int>(ModThreeState.S0);

        // Act & Assert
        Assert.Throws<ArgumentException>(() => fsm.ProcessInputs("102")); // '2' is invalid input
    }

    [Fact]
    public void ModThreeFSM_CanBeReset()
    {
        // Arrange
        var fsm = new FiniteStateMachine<char, int>(ModThreeState.S0);

        // Act
        fsm.ProcessInputs("11"); // Should end in state 2
        fsm.Reset(ModThreeState.S0);
        var result = fsm.ProcessInputs("1"); // Should end in state 1

        // Assert
        Assert.Equal(1, result);
    }
}
