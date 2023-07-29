namespace Kata.Tests;

public class ReaderServiceTests
{
    private IReaderService _readerService;

    [SetUp]
    public void Setup()
    {
        _readerService = new ReaderService();
    }

    [Test]
    public void GIVEN_DelimitedNumbers_WHEN_GettingParsedNumbersFromInput_RETURNS_ParsedNumbers()
    {
        // Arrange
        var input = "1,2,3";
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _readerService.GetParsedNumbersFromInput(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_SingleDelimiterAndDelimitedNumbers_WHEN_GettingParsedNumbersFromInput_RETURNS_ParsedNumbers()
    {
        // Arrange
        var input = "//*\n1*2*3";
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _readerService.GetParsedNumbersFromInput(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_MultipleDelimitersAndDelimitedNumbers_WHEN_GettingParsedNumbersFromInput_RETURNS_ParsedNumbers()
    {
        // Arrange
        var input = "//[*][%]\n1*2%3";
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _readerService.GetParsedNumbersFromInput(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_SingleMulticharacterDelimiterAndDelimitedNumbers_WHEN_GettingParsedNumbersFromInput_RETURNS_ParsedNumbers()
    {
        // Arrange
        var input = "//***\n1***2***3";
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _readerService.GetParsedNumbersFromInput(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_SingleMulticharacterDelimiterEqualToDelimiterLinePrefix_WHEN_GettingParsedNumbersFromInput_RETURNS_ParsedNumbers()
    {
        // Arrange
        var input = "////\n1//2//3";
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _readerService.GetParsedNumbersFromInput(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    // Aha! Found you
    [Test]
    public void GIVEN_SingleMulticharacterDelimiterEqualToMultiDelimiterSeparator_WHEN_GettingParsedNumbersFromInput_RETURNS_ParsedNumbers()
    {
        // Arrange
        var input = "//[]\n1[]2[]3";
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _readerService.GetParsedNumbersFromInput(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GIVEN_MultipleMulticharacterDelimitersAndDelimitedNumbers_WHEN_GettingParsedNumbersFromInput_RETURNS_ParsedNumbers()
    {
        // Arrange
        var input = "//[***][%%]\n1***2%%3";
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _readerService.GetParsedNumbersFromInput(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
