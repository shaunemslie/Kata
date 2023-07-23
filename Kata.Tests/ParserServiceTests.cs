namespace Kata.Tests;

public class ParserServiceTests
{
    private IParserService _parserService;

    [SetUp]
    public void Setup()
    {
        _parserService = new ParserService();
    }

    [Test]
    public void GetDelimitersFromFirstLine_GivenMultipleMultiAndSingleCharacterDelimiterInput_ReturnsExtractedDelimitersInList()
    {
        // Arrange
        var userInputFirstLine = "//[***][%%%][;][&]";
        var expected = new List<string> { "***", "%%%", ";", "&" };

        // Act
        var actual = _parserService.GetDelimitersFromFirstLine(userInputFirstLine);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetDelimitersFromFirstLine_GivenSingleMultiCharacterDelimiterInput_ReturnsExtractedDelimiterInList()
    {
        // Arrange
        var userInputFirstLine = "//***";
        var expected = new List<string> { "***" };

        // Act
        var actual = _parserService.GetDelimitersFromFirstLine(userInputFirstLine);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GetParsedNumbersFromUserInput_GivenMultiPlusSingleCharacterDelimitersAndUserInput_ReturnsExtractedParsedNumbers()
    {
        // Arrange
        var delimiters = new List<string> { "***", "%%%", ";", "&" };
        var userInputLessFirstLine = "1***2%%%3;4&5";

        // Act
        var actual = _parserService.GetParsedNumbersFromUserInput(delimiters, userInputLessFirstLine);

        // Assert
        Assert.That(actual, Is.TypeOf<List<int>>());
        Assert.That(actual, Is.GreaterThan(0));
    }

    /*     [Test] */
    /*     public void GetDelimitersFromFirstLine_GivenSingleCharacterDelimiterInput_ReturnsExtractedDelimiterInList() */
    /*     { */
    /*         // Arrange */
    /*         var userInputFirstLine = "//;"; */
    /*         var expected = new List<string> { ";" }; */

    /*         // Act */
    /*         var actual = _parserService.GetDelimitersFromFirstLine(userInputFirstLine); */

    /*         // Assert */
    /*         Assert.That(actual, Is.EqualTo(expected)); */
    /*     } */
}
