namespace Kata.Tests;

public class CalculatorServiceTests
{
    private ICalculatorService _calculatorService;

    [SetUp]
    public void Setup()
    {
        _calculatorService = new CalculatorService();
    }

    [Test]
    public void GIVEN_EmptyInput_WHEN_Adding_RETURNS_Zero()
    {
        // Arrange
        var input = string.Empty;

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.Zero);
    }

    [Test]
    public void GIVEN_InputWithOneNumber_WHEN_Adding_RETURNS_Number()
    {
        // Arrange
        var input = "1";
        var expected = 1;

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
