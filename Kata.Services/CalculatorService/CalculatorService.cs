namespace Kata.Services;

public class CalculatorService : ICalculatorService
{
    private IReaderService _readerService;

    public CalculatorService()
    {
        _readerService = new ReaderService();
    }

    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        if (isSingleNumber(numbers))
        {
            return int.Parse(numbers);
        }

        var parsedNumbers = _readerService.GetParsedNumbersFromInput(numbers);
        var validNumbers = GetValidatedNumbers(parsedNumbers);
        var sum = validNumbers.Sum();

        return sum;
    }

    private IEnumerable<int> GetValidatedNumbers
    (
        IEnumerable<int> numbersToCheck,
        int lowerLimitThrows = 0,
        int upperLimitInclusive = 1000
    )
    {
        var belowLowerLimit = numbersToCheck.Where(x => x < lowerLimitThrows);

        if (!belowLowerLimit.Any())
        {
            var belowUpperLimitInclusive = numbersToCheck.Where(x => x <= upperLimitInclusive);
            return belowUpperLimitInclusive;
        }

        var exceptionList = string.Join(',', belowLowerLimit);
        var exceptionMessage = $"Negatives not allowed: {exceptionList}";

        throw new Exception(exceptionMessage);
    }

    private bool isSingleNumber(string input)
    {
        if (input.Trim().Length == 1)
        {
            return int.TryParse(input.Trim(), out _);
        }
        return false;
    }
}
