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

        var (isSingleNumber, parsedNumber) = GetCheckedIsAndParsedSingleNumber(numbers);

        if (isSingleNumber)
        {
            return parsedNumber;
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

    private (bool, int) GetCheckedIsAndParsedSingleNumber(string input)
    {
        var inputLessWhitespace = input.Trim();

        if (inputLessWhitespace.Length != 1)
        {
            return (false, 0);
        }

        var parsedNumber = 0;
        var isNumber = int.TryParse(inputLessWhitespace, out parsedNumber);

        return (isNumber, parsedNumber);
    }
}
