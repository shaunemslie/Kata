namespace Kata.Tests.Services;
public class CalculatorServiceTests
{
    private ICalculatorService _calculatorService;

    [SetUp]
    public void Setup()
    {
        _calculatorService = new CalculatorService();
    }

    [Test]
    public void Given_PositiveAndNegativeSummands_When_GettingValidatedSummands_ThrowsNoNegativesAllowedExceptionAndNegativesListMessage()
    {
        // Arrange
        var input = new int[] { 1, 2, -1, -2, -3 };
        var expectedExceptionMessage = "Negatives not allowed: -1,-2,-3";

        // Act & Assert
        Assert.Throws(
            Is.TypeOf<Exception>()
            .And.Message.EqualTo(expectedExceptionMessage),
            () => _calculatorService.GetValidatedSummands(input)
        );
    }

    [Test]
    public void Given_SummandsAboveAndBelow1000_When_GettingValidatedSummands_ReturnsSummandsBelow1000()
    {
        // Arrange
        var input = new int[] { 2, 1001 };
        var expected = new int[] { 2 };

        // Act
        var actual = _calculatorService.GetValidatedSummands(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Given_Summands_When_Summing_ReturnsSum()
    {
        // Arrange
        var input = new int[] { 1, 2, 3 };
        var expected = 6;

        // Act
        var actual = _calculatorService.Sum(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
