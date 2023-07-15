using Kata.Services;

namespace Kata.Tests;

public class SumServiceTests
{
    private ISumService? _sumService;

    [SetUp]
    public void Setup()
    {
        ISumService _sumService = new SumService();
    }

    [Test]
    public void Given_NegativeAndPositiveValues_Returns_NegativesExclusive()
    {
        // Arrange
        var values = new List<int> { 0, -1, 2, 2, -3, -3, 4 };
        var expected = new List<int> { -1, -3, -3 }; // Could probably remove this

        // Act
        var actual = _sumService!.GetNegatives(values);

        // Assert
        Assert.That(actual, Is.EqualTo(expected)); // Could probably remove this
        Assert.That(actual.Max(), Is.Negative);
        Assert.That(actual.Min(), Is.Negative);
    }

    [Test]
    public void Given_PositiveValues_Returns_Empty()
    {
        // Arrange
        var values = new List<int> { 0, 1, 2, 2, 3, 4 };

        // Act
        var actual = _sumService!.GetNegatives(values);

        // Assert
        Assert.That(actual, Is.Empty);
    }

    [Test]
    public void Given_ValuesBelowAndAbove_OneThousand_Returns_Below_OneThousandInclusive()
    {
        // Arrange
        var values = new List<int> { 0, 1, 1, 2, 1000, 1000, 1001, 1001, 1002 };
        var expected = new List<int> { 0, 1, 1, 2, 1000, 1000 }; // Could probably remove this

        // Act
        var actual = _sumService!.GetValidNumbers(values);

        // Assert
        Assert.That(actual, Is.EqualTo(expected)); // Could probably remove this
        Assert.That(actual.Max(), Is.LessThanOrEqualTo(1000));
    }
}
