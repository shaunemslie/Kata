using Kata.Helpers;
using Kata.Services;

namespace Kata;
public class Calculator
{
    private readonly IReaderService _readerService;
    private readonly ICalculatorService _calculatorService;

    private readonly ILimitValidator _limitValidator;

    public Calculator(IReaderService readerService, ICalculatorService calculatorService, ILimitValidator limitValidator)
    {
        _readerService = readerService;
        _calculatorService = calculatorService;

        _limitValidator = limitValidator;
    }

    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        const string DelimiterLinePrefix = "//";
        var delimiters = new List<string> { ",", "\n" };

        var parsedSummands = _readerService.ParseNumbersFromInput(numbers, DelimiterLinePrefix, delimiters);

        const string NegativesExceptionMessage = "Negatives are prohibited: ";
        var outsideLimitMatch = new Predicate<int>(number => number < 0);

        _limitValidator.ValidateWithinLimit(parsedSummands, outsideLimitMatch, NegativesExceptionMessage);
        var withinRange = Array.FindAll(parsedSummands, number => number <= 1000);

        return _calculatorService.Sum(withinRange);
    }

    public int Subtract(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        const string DelimiterLinePrefix = "##";
        var delimiters = new List<string> { ",", "\n" };

        var parsedSubtrahends = _readerService.ParseNumbersFromInput(numbers, DelimiterLinePrefix, delimiters);

        const string NegativesExceptionMessage = "Numbers greater than 1000 are prohibited: ";
        var outsideLimitMatch = new Predicate<int>(number => number > 1000);

        _limitValidator.ValidateWithinLimit(parsedSubtrahends, outsideLimitMatch, NegativesExceptionMessage);

        return _calculatorService.Sum(parsedSubtrahends);
    }
}
