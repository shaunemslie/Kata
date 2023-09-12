namespace Kata.Services;

public class CalculatorService : ICalculatorService
{
    private readonly IReaderService _readerService;

    public CalculatorService(IReaderService readerService)
    {
        _readerService = readerService;
    }

    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        var parsedNumbers = _readerService.GetParsedNumbersFromInput(numbers);
        var validNumbers = GetValidatedNumbers(parsedNumbers);

        return Sum(validNumbers);
    }

    private int[] GetValidatedNumbers(int[] numbersToCheck)
    {
        var negatives = Array.FindAll(numbersToCheck, number => number < 0);

        if (negatives?.Length > 0)
        {
            var exceptionList = string.Join(',', negatives);
            var exceptionMessage = $"Negatives not allowed: {exceptionList}";

            throw new Exception(exceptionMessage);
        }

        var validNumbers = Array.FindAll(numbersToCheck, number => number <= 1000);

        return validNumbers;
    }

    private int Sum(int[] numbers)
    {
        var sum = 0;
        Array.ForEach(numbers, number => sum += number);

        return sum;
    }
}
