namespace Kata.Tests;

public class CalculatorServiceTests
{
    [TestFixture]
    public class SuccessTests
    {
        [Test]
        public void Add_GivenEmptyInput_WhenPassedEmptyString_ReturnsZero()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var input = string.Empty;

            // Act
            var actual = _calculatorService.Add(input);

            // Assert
            Assert.That(actual, Is.Zero);
        }

        [Test]
        public void Add_GivenInput_WhenPassedOneNumber_ReturnsNumber()
        {
            // Arrange
            var _calculatorService = new CalculatorService();

            // Act
            var actual = _calculatorService.Add("1");

            // Assert
            Assert.That(actual, Is.EqualTo(1));
        }

        [Test]
        public void Add_GivenInput_WhenPassedTwoDelimitedNumbers_ReturnsSumNumbers()
        {
            // Arrange
            var _calculatorService = new CalculatorService();

            // Act
            var actual = _calculatorService.Add("1,2");

            // Assert
            Assert.That(actual, Is.EqualTo(3));
        }

        [Test]
        public void Add_GivenInput_WhenPassedNAmountOfNumbers_ReturnsSumNumbers()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var n = Math.Max(0, new Random().Next(0, 1000));
            var input = string.Join(",", Enumerable.Range(0, n));
            var expected = Enumerable.Range(0, n).Sum();

            // Act
            var actual = _calculatorService.Add(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_GivenInputWithNewlines_WhenPassedThreeDelimitedNumbers_ReturnsSumNumbers()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var input = "1\n2,3";
            var expected = 6;

            // Act
            var actual = _calculatorService.Add(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_GivenInputWithASingleCustomDelimiter_WhenPassedTwoDelimitedNumbers_ReturnsSumNumbers()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var input = "//;\n1;2";
            var expected = 3;

            // Act
            var actual = _calculatorService.Add(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_GivenInputWithNumberGreaterThan1000_WhenPassedNAmountOfNumbers_ReturnsSumNumbersExcludingGreaterThan1000()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var input = "2,1001";
            var expected = 2;

            // Act
            var actual = _calculatorService.Add(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_GivenInputWithASingleMultiCharCustomDelimiter_WhenPassedThreeDelimitedNumbers_ReturnsSumNumbers()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var input = "//***\n1***2***3";
            var expected = 6;

            // Act
            var actual = _calculatorService.Add(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_GivenInputWithMultipleSingleCharCustomDelimiters_WhenPassedThreeDelimitedNumbers_ReturnsSumNumbers()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var input = "//[*][%]\n1*2%3";
            var expected = 6;

            // Act
            var actual = _calculatorService.Add(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_GivenInputWithMultipleMultiAndSingleCharCustomDelimiters_WhenPassedNAmountOfNumbers_ReturnsSumNumbers()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var input = "//[***][%%][&]\n1***2%%3&4";
            var expected = 10;

            // Act
            var actual = _calculatorService.Add(input);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    [TestFixture]
    public class FailureTests
    {
        [Test]
        public void Add_GivenInputWithNegative_WhenPassedTwoDelimitedNumbers_ThrowsNegativesNotAllowed()
        {
            // Arrange
            var _calculatorService = new CalculatorService();
            var input = "1,-2";
            var expectedExceptionMessage = "Negatives not allowed: -2";

            // Act & Assert
            Assert.That(() => _calculatorService.Add(input), Throws.TypeOf<Exception>().With.Message.EqualTo(expectedExceptionMessage));
        }
    }
}
