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

    // TODO: Refactor Add method ->
    // Check for a single character and whether it's a number or not.
    // If it's not a number, continue, otherwise return parsed number.
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

    [Test]
    public void GIVEN_InputWithTwoDelimitedNumbers_WHEN_Adding_RETURNS_SumOfNumbers()
    {
        // Arrange
        var input = "1,2";
        var expected = 3;

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new List<int> { 1, 2 });

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

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 });

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_NumbersAbove1000_WHEN_Adding_RETURNS_SumOfNumbersLessThanOrEqualTo1000()
    {
        // Arrange
        var input = "1000,1001";

        _readerServiceMock
            .GetParsedNumbersFromInput(Arg.Any<string>())
            .Returns(new List<int> { 1000, 1001 });

        // Act
        var actual = _calculatorService.Add(input);

        // Assert
        Assert.That(actual, Is.LessThanOrEqualTo(1000));
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
        // NOTE: Found this on the NUnit docs, see below note (brainstorm) to maybe separate the assertion?
        Assert.Throws(
            Is.TypeOf<Exception>()
            .And.Message.EqualTo(expectedExceptionMessage),
            () => _calculatorService.Add(input)
        );
    }

    // just commented this out, separation isn't that cool lol, get too excited sometimes
    //
/*     [Test] */
/*     public void GIVEN_NumbersWithNegativeValues_WHEN_Adding_THROWS_NegativesNotAllowedException_BRAINSTORM_TEST() */
/*     { */
/*         // Arrange */
/*         var input = "-1,2,-3,4"; */
/*         var expectedExceptionMessage = "Negatives not allowed: -1,-3"; */

/*         _readerServiceMock */
/*             .GetParsedNumbersFromInput(Arg.Any<string>()) */
/*             .Returns(new List<int> { -1, 2, -3, 4 }); */

/*         // Act */
/*         // NOTE:(brainstorm) */
/*         var actual = () => _calculatorService.Add(input); */

/*         // Assert */
/*         var exception = Assert.Throws( */
/*             Is.TypeOf<Exception>(), */
/*             () => actual.Invoke() */
/*         ); */
/*         Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage)); */
/*     } */

/*     [Test] */
/*     public void GIVEN_NumbersWithNegativeValues_WHEN_Adding_THROWS_NegativesNotAllowedException_BRAINSTORM_TEST_TWO() */
/*     { */
/*         // Arrange */
/*         var input = "-1,2,-3,4"; */
/*         var expectedExceptionMessage = "Negatives not allowed: -1,-3"; */

/*         _readerServiceMock */
/*             .GetParsedNumbersFromInput(Arg.Any<string>()) */
/*             .Returns(new List<int> { -1, 2, -3, 4 }); */

/*         // Act */
/*         var actual = () => _calculatorService.Add(input); */

/*         // Assert */
/*         // NOTE: you can extract the IsTypeOf arg/assertion to the assert method return type?!?! whattttt, so cool */
/*         var exception = Assert.Throws<Exception>(() => actual.Invoke()); */
/*         Assert.That(exception.Message, Is.EqualTo(expectedExceptionMessage)); */
/*     } */
}
