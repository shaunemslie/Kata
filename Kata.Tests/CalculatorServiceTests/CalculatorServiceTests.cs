namespace Kata.Tests;

public class CalculatorServiceTests
{
    private IReaderService _readerServiceMock;
    private ICalculatorService _calculatorService;

    [SetUp]
    public void SetUp()
    {
        _readerServiceMock = Substitute.For<IReaderService>();
        _calculatorService = new CalculatorService(_readerServiceMock);
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
    public void GIVEN_NumbersAbove1000_WHEN_Adding_RETURNS_SumOfNumbersLessThanOrEqualTo1000()
    {
        // Arrange
        var input = "5,1000,1001";
        var expected = 1005;

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new int[] { 5, 1000, 1001 });

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_NumbersWithNegativeValues_WHEN_Adding_THROWS_NegativesNotAllowedException()
    {
        // Arrange
        var input = "-1,2,-3,4";
        var expectedExceptionMessage = "Negatives not allowed: -1,-3";

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new int[] { -1, 2, -3, 4 });

        Assert.Throws(
            Is.TypeOf<Exception>()
            .And.Message.EqualTo(expectedExceptionMessage),
            () => _calculatorService.Add(input)
        );
    }
}
