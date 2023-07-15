using Kata.Services;

namespace Kata.Tests;

public class ParserServiceTests
{
    private IParserService? _parserService;

    [SetUp]
    public void Setup()
    {
        IParserService _parserService = new ParserService();
    }

    [Test]
    public void Given_UserInput_With_MultipleDelimiters_Returns_DefaultsAndMultipleDelimiters()
    {
        // Arrange
        var userInput = "//[#][%][***]";
        var expected = new List<string> { ",", "\n", "#", "%", "***" };

        // Act
        var actual = _parserService!.GetDelimitersFromUserInput(userInput);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    public void Given_UserInput_With_SingleDelimiter_Returns_DefaultsAndSingleDelimiter()
    {
        // Arrange
        var userInput = "//***";
        var expected = new List<string> { ",", "\n", "***" };

        // Act
        var actual = _parserService!.GetDelimitersFromUserInput(userInput);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    public void Given_UserInput_Without_Delimiter_Returns_Defaults()
    {
        var userInput = "1,2,3";
        var expected = new List<string> { ",", "\n" };

        // Act
        var actual = _parserService!.GetDelimitersFromUserInput(userInput);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    public void Given_UserInput_And_DelimiterList_Returns_ParsedNumbers()
    {
        var userInput = "//***\n1***2***3";
        var delimiters = new List<string> { ",", "\n", "***", };
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _parserService!.GetNumbersFromUserInput(userInput, delimiters);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
