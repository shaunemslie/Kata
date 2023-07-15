using Kata.Services;

namespace Kata.Tests;

public class ParserServiceTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Given_UserInput_With_MultipleDelimiters_Returns_DefaultsAndMultipleDelimiters()
    {
        // Arrange
        var parserService = new ParserService();
        var userInput = "//[#][%][***]";
        var expected = new List<string> { ",", "\n", "#", "%", "***" };

        // Act
        var actual = parserService.GetDelimitersFromUserInput(userInput);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    public void Given_UserInput_With_SingleDelimiter_Returns_DefaultsAndSingleDelimiter()
    {
        // Arrange
        var parserService = new ParserService();
        var userInput = "//***";
        var expected = new List<string> { ",", "\n", "***" };

        // Act
        var actual = parserService.GetDelimitersFromUserInput(userInput);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    public void Given_UserInput_Without_Delimiter_Returns_Defaults()
    {
        var parserService = new ParserService();
        var userInput = "1,2,3";
        var expected = new List<string> { ",", "\n" };

        // Act
        var actual = parserService.GetDelimitersFromUserInput(userInput);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    public void Given_UserInput_And_DelimiterList_Returns_ParsedNumbers()
    {
        var parserService = new ParserService();
        var userInput = "//***\n1***2***3";
        var delimiters = new List<string> { ",", "\n", "***", };
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = parserService.GetNumbersFromUserInput(userInput, delimiters);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
