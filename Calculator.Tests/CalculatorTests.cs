using Calculator.Core;
using Xunit;

namespace Calculator.Tests;

public class CalculatorTests
{
    private readonly Core.Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Core.Calculator();
    }

    // Addition Tests
    [Fact]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange
        int a = 5;
        int b = 3;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(8, result);
    }

    [Theory]
    [InlineData(5, 3, 8)]
    [InlineData(-5, 3, -2)]
    [InlineData(-5, -3, -8)]
    [InlineData(0, 5, 5)]
    public void Add_VariousInputs_ReturnsCorrectSum(int a, int b, int expected)
    {
        var result = _calculator.Add(a, b);
        Assert.Equal(expected, result);
    }

    // Subtraction Tests
    [Fact]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        Assert.Equal(2, _calculator.Subtract(5, 3));
        Assert.Equal(8, _calculator.Subtract(5, -3));
    }

    // Multiplication Tests
    [Theory]
    [InlineData(5, 3, 15)]
    [InlineData(5, -3, -15)]
    [InlineData(5, 0, 0)]
    public void Multiply_VariousInputs_ReturnsProduct(int a, int b, int expected)
    {
        Assert.Equal(expected, _calculator.Multiply(a, b));
    }

    // Division Tests
    [Fact]
    public void Divide_TwoNumbers_ReturnsQuotient()
    {
        Assert.Equal(2, _calculator.Divide(6, 3));
        Assert.Equal(-2, _calculator.Divide(6, -3));
    }

    [Fact]
    public void Divide_ByZero_ThrowsException()
    {
        // Assert
        var exception = Assert.Throws<DivideByZeroException>(
            () => _calculator.Divide(5, 0)
        );
        
        Assert.Equal("Cannot divide by zero", exception.Message);
    }
}