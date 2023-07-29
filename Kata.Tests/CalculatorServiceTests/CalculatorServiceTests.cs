namespace Kata.Tests;

public class CalculatorServiceTests
{
    private ICalculatorService _calculatorService;
    private IReaderService _readerServiceMock;

    [SetUp]
    public void Setup()
    {
        _calculatorService = new CalculatorService();
        _readerServiceMock = Substitute.For<IReaderService>();
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
    public void GIVEN_InputWithOneNumberAndWhitespace_WHEN_Adding_RETURNS_ParsedNumber()
    {
        // Arrange
        var input = " 12  ";
        var expected = 12;

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_InputWithTwoDelimitedNumbers_WHEN_Adding_RETURNS_SumOfNumbers()
    {
        // Arrange
        var input = "1,2";
        var expected = 3;

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_InputWithNAmountOfNumbers_WHEN_Adding_RETURNS_SumOfNumbers()
    {
        // Arrange
        var input = "1,2,3,4,5,6,7,8";
        var expected = 36;

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    // TODO: Refactor Calculator class ->
    // Could perhaps create a wrapper for the GetValidatedNumbersMethod to
    // improve testability and readability (allows me to use the Is.LessThanOrEqualTo
    // assertion which read better than the below equalTo.)
    [Test]
    public void GIVEN_NumbersAbove1000_WHEN_Adding_RETURNS_SumOfNumbersLessThanOrEqualTo1000()
    {
        // Arrange
        var input = "5,1000,1001";
        var expected = 1005;

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new List<int> { 5, 1000, 1001 });

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
            .Returns(new List<int> { -1, 2, -3, 4 });

        // Act & Assert
        // NOTE: Found this on the NUnit docs, see below (brainstorm) to maybe separate the assertion?
        Assert.Throws(
            Is.TypeOf<Exception>()
            .And.Message.EqualTo(expectedExceptionMessage),
            () => _calculatorService.Add(input)
        );
    }

    [Test]
    [Ignore("Ignore: brainstorm")]
    public void GIVEN_NumbersAbove1000_WHEN_Adding_RETURNS_SumOfNumbersLessThanOrEqualTo1000_BRAINSTORM()
    {
        // Arrange
        var input = "1000,1001";
        var expectedEqualToOrLessThan = 1000;

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new List<int> { 1000, 1001 });

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.LessThanOrEqualTo(expectedEqualToOrLessThan));
    }

    [Test]
    [Ignore("Ignore: brainstorm")]
    public void GIVEN_NumbersWithNegativeValues_WHEN_Adding_THROWS_NegativesNotAllowedException_BRAINSTORM_TEST()
    {
        // Arrange
        var input = "-1,2,-3,4";
        var expectedExceptionMessage = "Negatives not allowed: -1,-3";

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new List<int> { -1, 2, -3, 4 });

        // Act
        var actual = () => _calculatorService.Add(input);

        // Assert
        var exception = Assert.Throws(
            Is.TypeOf<Exception>(),
            () => actual.Invoke()
        );
        Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
    }

    [Test]
    [Ignore("Ignore: brainstorm")]
    public void GIVEN_NumbersWithNegativeValues_WHEN_Adding_THROWS_NegativesNotAllowedException_BRAINSTORM_TEST_TWO()
    {
        // Arrange
        var input = "-1,2,-3,4";
        var expectedExceptionMessage = "Negatives not allowed: -1,-3";

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new List<int> { -1, 2, -3, 4 });

        // Act
        var actual = () => _calculatorService.Add(input);

        // Assert
        var exception = Assert.Throws<Exception>(() => actual.Invoke());
        Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage));
    }
}
