namespace Kata.Tests.Services;
public class ReaderServiceTests
{
    const string AdditionDelimiterLinePrefix = "//";
    const string SubtractionDelimiterLinePrefix = "##";

    private List<string> _delimiters;
    private IStringReaderWrapper _stringReaderWrapperMock;
    private IReaderService _readerService;

    [SetUp]
    public void Setup()
    {
        _delimiters = new List<string> { ",", "\n" };
        _stringReaderWrapperMock = Substitute.For<IStringReaderWrapper>();
        _readerService = new ReaderService(_stringReaderWrapperMock);
    }

    [Test]
    public void Given_ValidInputOfOneCharacter_When_GettingParsedSummandsFromInput_ReturnsParsedInput()
    {
        // Arrange
        var input = "1";
        var expected = new int[] { 1 };

        _stringReaderWrapperMock.ReadToEnd().Returns(input);

        // Act
        var actual = _readerService.ParseNumbersFromInput(input, AdditionDelimiterLinePrefix, _delimiters);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    /* [Test] */
    /* public void Given_ValidInputWithDefaultDelimiter_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() */
    /* { */
    /*     // Arrange */
    /*     var input = "1,2"; */
    /*     var expected = new int[] { 1, 2 }; */

    /*     var inputLessDelimitersInline = "1,2"; */
    /*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); */

    /*     // Act */
    /*     var actual = _readerService.GetParsedSummandsFromInput(input); */

    /*     // Assert */
    /*     Assert.That(actual, Is.EqualTo(expected)); */
    /* } */

    /* [Test] */
    /* public void Given_ValidInputWithDefaultDelimiters_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() */
    /* { */
    /*     // Arrange */
    /*     var input = "1\n2,3"; */
    /*     var expected = new int[] { 1, 2, 3 }; */

    /*     var inputLessDelimitersInline = "1\n2,3"; */
    /*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); */

    /*     // Act */
    /*     var actual = _readerService.GetParsedSummandsFromInput(input); */

    /*     // Assert */
    /*     Assert.That(actual, Is.EqualTo(expected)); */
    /* } */

    /* [Test] */
    /* public void Given_ValidInputWithCustomSingleCharacterDelimiter_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() */
    /* { */
    /*     // Arrange */
    /*     var input = "//;\n1;2"; */
    /*     var expected = new int[] { 1, 2 }; */

    /*     var delimitersInline = "//;"; */
    /*     var inputLessDelimitersInline = "1;2"; */
    /*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); */
    /*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); */

    /*     // Act */
    /*     var actual = _readerService.GetParsedSummandsFromInput(input); */

    /*     // Assert */
    /*     Assert.That(actual, Is.EqualTo(expected)); */
    /* } */

    /* [Test] */
    /* public void Given_ValidInputWithCustomMultiCharacterDelimiter_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() */
    /* { */
    /*     // Arrange */
    /*     var input = "//***\n1***2***3"; */
    /*     var expected = new int[] { 1, 2, 3 }; */

    /*     var delimitersInline = "//***"; */
    /*     var inputLessDelimitersInline = "1***2***3"; */
    /*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); */
    /*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); */

    /*     // Act */
    /*     var actual = _readerService.GetParsedSummandsFromInput(input); */

    /*     // Assert */
    /*     Assert.That(actual, Is.EqualTo(expected)); */
    /* } */

    /* [Test] */
    /* public void Given_ValidInputWithMultipleCustomSingleCharacterDelimiters_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() */
    /* { */
    /*     // Arrange */
    /*     var input = "//[*][%]\n1*2%3"; */
    /*     var expected = new int[] { 1, 2, 3 }; */

    /*     var delimitersInline = "//[*][%]"; */
    /*     var inputLessDelimitersInline = "1*2%3"; */
    /*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); */
    /*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); */

    /*     // Act */
    /*     var actual = _readerService.GetParsedSummandsFromInput(input); */

    /*     // Assert */
    /*     Assert.That(actual, Is.EqualTo(expected)); */
    /* } */

    /* [Test] */
    /* public void Given_ValidInputWithMultipleCustomMultiCharacterAndSingleCharacterDelimiters_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() */
    /* { */
    /*     // Arrange */
    /*     var input = "//[***][%%][#]\n1***2%%3#4"; */
    /*     var expected = new int[] { 1, 2, 3, 4 }; */

    /*     var delimitersInline = "//[***][%%][#]"; */
    /*     var inputLessDelimitersInline = "1***2%%3#4"; */
    /*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); */
    /*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); */

    /*     // Act */
    /*     var actual = _readerService.GetParsedSummandsFromInput(input); */

    /*     // Assert */
    /*     Assert.That(actual, Is.EqualTo(expected)); */
    /* } */

    /* Could also use this slick TestCase attribute, not sure if you'd accept this though.. best to stick to standard practice I guess */
    /* [TestCase("//[*][&&]\n1*2&&3", new int[] { 1, 2, 3 }, "//[*][&&]", "1*2&&3")] */
    /* public void Given_ValidInputWithMultipleDelimiters_When_GettingParsedSummandsFromInput_ReturnsParsedSummands(string input, int[] expected, string delimitersInline, string inputLessDelimitersInline) */
    /* { */
    /*     // Arrange */
    /*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); */
    /*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); */

    /*     // Act */
    /*     var actual = _readerService.GetParsedSummandsFromInput(input); */

    /*     // Assert */
    /*     Assert.That(actual, Is.EqualTo(expected)); */
    /* } */
}
