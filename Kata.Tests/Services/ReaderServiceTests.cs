namespace Kata.Tests.Services;
public class ReaderServiceTests
{
    const string DelimitersDefinitionPrefix = "&&";
    const string SeparatorsDefinitionClosure = "<>";

    private List<string> _delimiters;
    private List<char> _separators;

    private IStringReaderWrapper _stringReaderWrapperMock;
    private IReaderService _readerService;

    [SetUp]
    public void Setup()
    {
        _delimiters = new List<string> { ",", "\n" };
        _separators = new List<char> { '[', ']' };

        _stringReaderWrapperMock = Substitute.For<IStringReaderWrapper>();
        _readerService = new ReaderService(_stringReaderWrapperMock);
    }

    [Test]
    public void Given_ValidInputOfOneNumber_When_GettingParsedSummandsFromInput_ReturnsParsedNumber()
    {
        // Arrange
        var input = "1";
        var expected = new int[] { 1 };

        _stringReaderWrapperMock.ReadToEnd().Returns(input);

        // Act
        var actual = _readerService.ReadAndParseInput(input, DelimitersDefinitionPrefix, SeparatorsDefinitionClosure, _separators, _delimiters);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Given_MultipleNumbers_When_GettingParsedNumbersFromInput_ReturnsParsedNumbers()
    {
        // Arrange
        var input = "1,2";
        var expected = new int[] { 1, 2 };

        _stringReaderWrapperMock.ReadToEnd().Returns(input);

        // Act
        var actual = _readerService.ReadAndParseInput(input, DelimitersDefinitionPrefix, SeparatorsDefinitionClosure, _separators, _delimiters);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Given_MultipleNumbersAndNewlines_When_GettingParsedNumbersFromInput_ReturnsParsedNumbers()
    {
        // Arrange
        var input = "1\n2,3";
        var expected = new int[] { 1, 2, 3 };

        _stringReaderWrapperMock.ReadToEnd().Returns(input);

        // Act
        var actual = _readerService.ReadAndParseInput(input, DelimitersDefinitionPrefix, SeparatorsDefinitionClosure, _separators, _delimiters);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void Given_MultipleNumbersAndCustomDelimiter_When_GettingParsedNumbersFromInput_ReturnsParsedNumbers()
    {
        // Arrange
        var input = "&&;\n1;2";
        var expected = new int[] { 1, 2 };

        _stringReaderWrapperMock.ReadToEnd().Returns(input);

        // Act
        var actual = _readerService.ReadAndParseInput(input, DelimitersDefinitionPrefix, SeparatorsDefinitionClosure, _separators, _delimiters);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    /*     [Test] */
    /*     public void Given_Returns() */
    /*     { */
    /*         // Arrange */
    /*         var input = "##;\n1;2"; */
    /*         var expected = new List<int> { 1, 2 }; */

    /*         const string SeparatorsDefinitionClosure = "<>"; */
    /*         const string DelimitersDefinitionPrefix = "##"; */
    /*         var defaultDelimiters = new HashSet<string> { ",", "\n" }; */
    /*         var defaultSeparators = new HashSet<char> { '[', ']' }; */

    /*         _stringReaderWrapperMock.Peek().Returns(35); */
    /*         var delimitersDefinition = ";"; */
    /*         _stringReaderWrapperMock.ReadLine().Returns(delimitersDefinition); */
    /*         var inputLessDefinitions = "1;2"; */
    /*         _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDefinitions); */

    /*         // Act */
    /*         var actual = _readerService.ParseNumbersFromInput(input, SeparatorsDefinitionClosure, DelimitersDefinitionPrefix, defaultDelimiters, defaultSeparators); */

    /*         // Assert */
    /*         Assert.That(actual, Is.EqualTo(expected)); */
    /*     } */

    /*     [Test] */
    /*     public void Given_Returns2() */
    /*     { */
    /*         // Arrange */
    /*         var input = "##[***]\n1***2***3"; */
    /*         var expected = new List<int> { 1, 2, 3 }; */

    /*         const string SeparatorsDefinitionClosure = "<>"; */
    /*         const string DelimitersDefinitionPrefix = "##"; */
    /*         var defaultDelimiters = new HashSet<string> { ",", "\n" }; */
    /*         var defaultSeparators = new HashSet<char> { '[', ']' }; */

    /*         _stringReaderWrapperMock.Peek().Returns(35); */
    /*         var delimitersDefinition = "[***]"; */
    /*         _stringReaderWrapperMock.ReadLine().Returns(delimitersDefinition); */
    /*         var inputLessDefinitions = "1***2***3"; */
    /*         _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDefinitions); */

    /*         // Act */
    /*         var actual = _readerService.ParseNumbersFromInput(input, SeparatorsDefinitionClosure, DelimitersDefinitionPrefix, defaultDelimiters, defaultSeparators); */

    /*         // Assert */
    /*         Assert.That(actual, Is.EqualTo(expected)); */
    /*     } */

    /*     [Test] */
    /*     public void Given_Returns3() */
    /*     { */
    /*         // Arrange */
    /*         var input = "##[*][%]\n1*2%3"; */
    /*         var expected = new List<int> { 1, 2, 3 }; */

    /*         const string SeparatorsDefinitionClosure = "<>"; */
    /*         const string DelimitersDefinitionPrefix = "##"; */
    /*         var defaultDelimiters = new HashSet<string> { ",", "\n" }; */
    /*         var defaultSeparators = new HashSet<char> { '[', ']' }; */

    /*         _stringReaderWrapperMock.Peek().Returns(35); */
    /*         var delimitersDefinition = "[*][%]"; */
    /*         _stringReaderWrapperMock.ReadLine().Returns(delimitersDefinition); */
    /*         var inputLessDefinitions = "1*2%3"; */
    /*         _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDefinitions); */

    /*         // Act */
    /*         var actual = _readerService.ParseNumbersFromInput(input, SeparatorsDefinitionClosure, DelimitersDefinitionPrefix, defaultDelimiters, defaultSeparators); */

    /*         // Assert */
    /*         Assert.That(actual, Is.EqualTo(expected)); */
    /*     } */

    /*     [Test] */
    /*     public void Given_Returns4() */
    /*     { */
    /*         // Arrange */
    /*         var input = "<(>)##(*)(%)\n1*2%3"; */
    /*         var expected = new List<int> { 1, 2, 3 }; */

    /*         const string SeparatorsDefinitionClosure = "<>"; */
    /*         const string DelimitersDefinitionPrefix = "##"; */
    /*         var defaultDelimiters = new HashSet<string> { ",", "\n" }; */
    /*         var defaultSeparators = new HashSet<char> { '(', ')' }; */

    /*         _stringReaderWrapperMock.Peek().Returns(35); */
    /*         var delimitersDefinition = "(*)(%)"; */
    /*         _stringReaderWrapperMock.ReadLine().Returns(delimitersDefinition); */
    /*         var inputLessDefinitions = "1*2%3"; */
    /*         _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDefinitions); */

    /*         // Act */
    /*         var actual = _readerService.ParseNumbersFromInput(input, SeparatorsDefinitionClosure, DelimitersDefinitionPrefix, defaultDelimiters, defaultSeparators); */

    /*         // Assert */
    /*         Assert.That(actual, Is.EqualTo(expected)); */
    /*     } */


    /*     [Test] */
    /*     public void Given_ReturnsParsedInput() */
    /*     { */
    /*         // Arrange */
    /*         var input = "<(>)##(*)\n1*2"; */
    /*         var expected = new List<int> { 1, 2 }; */

    /*         const string SeparatorsDefinitionClosure = "<>"; */
    /*         const string DelimitersDefinitionPrefix = "##"; */
    /*         var defaultDelimiters = new HashSet<string> { ",", "\n" }; */
    /*         var defaultSeparators = new HashSet<char> { '[', ']' }; */

    /*         _stringReaderWrapperMock.Peek().Returns(60, 47); */
    /*         var separatorsDefinition = "<(>)"; */
    /*         _stringReaderWrapperMock.ReadBlockBufferResult(0, 4).Returns(separatorsDefinition); */
    /*         var delimitersInline = "(*)"; */
    /*         _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); */
    /*         var inputLessDefinitions = "1*2"; */
    /*         _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDefinitions); */

    /*         // Act */
    /*         var actual = _readerService.ParseNumbersFromInput(input, SeparatorsDefinitionClosure, DelimitersDefinitionPrefix, defaultDelimiters, defaultSeparators); */

    /*         // Assert */
    /*         Assert.That(actual, Is.EqualTo(expected)); */
    /*     } */

    /*     /1* [Test] *1/ */
    /*     /1* public void Given_ValidInputWithDefaultDelimiter_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() *1/ */
    /*     /1* { *1/ */
    /*     /1*     // Arrange *1/ */
    /*     /1*     var input = "1,2"; *1/ */
    /*     /1*     var expected = new int[] { 1, 2 }; *1/ */

    /*     /1*     var inputLessDelimitersInline = "1,2"; *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); *1/ */

    /*     /1*     // Act *1/ */
    /*     /1*     var actual = _readerService.GetParsedSummandsFromInput(input); *1/ */

    /*     /1*     // Assert *1/ */
    /*     /1*     Assert.That(actual, Is.EqualTo(expected)); *1/ */
    /*     /1* } *1/ */

    /*     /1* [Test] *1/ */
    /*     /1* public void Given_ValidInputWithDefaultDelimiters_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() *1/ */
    /*     /1* { *1/ */
    /*     /1*     // Arrange *1/ */
    /*     /1*     var input = "1\n2,3"; *1/ */
    /*     /1*     var expected = new int[] { 1, 2, 3 }; *1/ */

    /*     /1*     var inputLessDelimitersInline = "1\n2,3"; *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); *1/ */

    /*     /1*     // Act *1/ */
    /*     /1*     var actual = _readerService.GetParsedSummandsFromInput(input); *1/ */

    /*     /1*     // Assert *1/ */
    /*     /1*     Assert.That(actual, Is.EqualTo(expected)); *1/ */
    /*     /1* } *1/ */

    /*     /1* [Test] *1/ */
    /*     /1* public void Given_ValidInputWithCustomSingleCharacterDelimiter_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() *1/ */
    /*     /1* { *1/ */
    /*     /1*     // Arrange *1/ */
    /*     /1*     var input = "//;\n1;2"; *1/ */
    /*     /1*     var expected = new int[] { 1, 2 }; *1/ */

    /*     /1*     var delimitersInline = "//;"; *1/ */
    /*     /1*     var inputLessDelimitersInline = "1;2"; *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); *1/ */

    /*     /1*     // Act *1/ */
    /*     /1*     var actual = _readerService.GetParsedSummandsFromInput(input); *1/ */

    /*     /1*     // Assert *1/ */
    /*     /1*     Assert.That(actual, Is.EqualTo(expected)); *1/ */
    /*     /1* } *1/ */

    /*     /1* [Test] *1/ */
    /*     /1* public void Given_ValidInputWithCustomMultiCharacterDelimiter_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() *1/ */
    /*     /1* { *1/ */
    /*     /1*     // Arrange *1/ */
    /*     /1*     var input = "//***\n1***2***3"; *1/ */
    /*     /1*     var expected = new int[] { 1, 2, 3 }; *1/ */

    /*     /1*     var delimitersInline = "//***"; *1/ */
    /*     /1*     var inputLessDelimitersInline = "1***2***3"; *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); *1/ */

    /*     /1*     // Act *1/ */
    /*     /1*     var actual = _readerService.GetParsedSummandsFromInput(input); *1/ */

    /*     /1*     // Assert *1/ */
    /*     /1*     Assert.That(actual, Is.EqualTo(expected)); *1/ */
    /*     /1* } *1/ */

    /*     /1* [Test] *1/ */
    /*     /1* public void Given_ValidInputWithMultipleCustomSingleCharacterDelimiters_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() *1/ */
    /*     /1* { *1/ */
    /*     /1*     // Arrange *1/ */
    /*     /1*     var input = "//[*][%]\n1*2%3"; *1/ */
    /*     /1*     var expected = new int[] { 1, 2, 3 }; *1/ */

    /*     /1*     var delimitersInline = "//[*][%]"; *1/ */
    /*     /1*     var inputLessDelimitersInline = "1*2%3"; *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); *1/ */

    /*     /1*     // Act *1/ */
    /*     /1*     var actual = _readerService.GetParsedSummandsFromInput(input); *1/ */

    /*     /1*     // Assert *1/ */
    /*     /1*     Assert.That(actual, Is.EqualTo(expected)); *1/ */
    /*     /1* } *1/ */

    /*     /1* [Test] *1/ */
    /*     /1* public void Given_ValidInputWithMultipleCustomMultiCharacterAndSingleCharacterDelimiters_When_GettingParsedSummandsFromInput_ReturnsParsedSummands() *1/ */
    /*     /1* { *1/ */
    /*     /1*     // Arrange *1/ */
    /*     /1*     var input = "//[***][%%][#]\n1***2%%3#4"; *1/ */
    /*     /1*     var expected = new int[] { 1, 2, 3, 4 }; *1/ */

    /*     /1*     var delimitersInline = "//[***][%%][#]"; *1/ */
    /*     /1*     var inputLessDelimitersInline = "1***2%%3#4"; *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); *1/ */

    /*     /1*     // Act *1/ */
    /*     /1*     var actual = _readerService.GetParsedSummandsFromInput(input); *1/ */

    /*     /1*     // Assert *1/ */
    /*     /1*     Assert.That(actual, Is.EqualTo(expected)); *1/ */
    /*     /1* } *1/ */

    /*     /1* Could also use this slick TestCase attribute, not sure if you'd accept this though.. best to stick to standard practice I guess *1/ */
    /*     /1* [TestCase("//[*][&&]\n1*2&&3", new int[] { 1, 2, 3 }, "//[*][&&]", "1*2&&3")] *1/ */
    /*     /1* public void Given_ValidInputWithMultipleDelimiters_When_GettingParsedSummandsFromInput_ReturnsParsedSummands(string input, int[] expected, string delimitersInline, string inputLessDelimitersInline) *1/ */
    /*     /1* { *1/ */
    /*     /1*     // Arrange *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadLine().Returns(delimitersInline); *1/ */
    /*     /1*     _stringReaderWrapperMock.ReadToEnd().Returns(inputLessDelimitersInline); *1/ */

    /*     /1*     // Act *1/ */
    /*     /1*     var actual = _readerService.GetParsedSummandsFromInput(input); *1/ */

    /*     /1*     // Assert *1/ */
    /*     /1*     Assert.That(actual, Is.EqualTo(expected)); *1/ */
    /*     /1* } *1/ */
}
