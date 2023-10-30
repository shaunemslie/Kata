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

        const string DelimiterSeperatorsDefinitionIndicators = "<>";
        const string DelimitersDefinitionIndicator = "//";
        var delimiters  = new HashSet<string>() { ",", "\n" };
        var separators = new HashSet<char>() { '[', ']' };

        var parsedSummands = _readerService.ParseNumbersFromInput(numbers, DelimiterSeperatorsDefinitionIndicators, DelimitersDefinitionIndicator, delimiters, separators);

        const string NegativesExceptionMessage = "Negative numbers are prohibited: ";
        var outsideLimitMatch = new Predicate<int>(number => number > 1000);
        _limitValidator.ValidateWithinLimit(parsedSummands, NegativesExceptionMessage, outsideLimitMatch);

        var withinRange = Array.FindAll(parsedSummands, number => number <= 1000);

        return _calculatorService.Sum(withinRange);
    }

    public int Subtract(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
            return 0;

        const string DelimiterSeperatorsDefinitionIndicators = "<>";
        const string DelimitersDefinitionIndicator = "##";
        var delimiters  = new HashSet<string>() { ",", "\n" };
        var separators = new HashSet<char>() { '[', ']' };

        var parsedSubtrahends = _readerService.ParseNumbersFromInput(numbers, DelimiterSeperatorsDefinitionIndicators, DelimitersDefinitionIndicator, delimiters, separators);

        const string RoofExceptionMessage = "Numbers greater than 1000 are prohibited: ";
        var outsideLimitMatch = new Predicate<int>(number => number > 1000);
        _limitValidator.ValidateWithinLimit(parsedSubtrahends, RoofExceptionMessage, outsideLimitMatch);

        return _calculatorService.Sum(parsedSubtrahends);
    }
}
