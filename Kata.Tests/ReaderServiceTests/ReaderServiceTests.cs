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
    public void GIVEN_NoCustomDelimitersAndDelimitedNumbers_WHEN_GettingParsedNumbersFromInput_RETURNS_ParsedNumbers()
    {
        // Arrange
        var input = "1,2,3";
        var expected = new List<int> { 1, 2, 3 };

        // Act
        var actual = _readerService.GetParsedNumbersFromInput(input);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
