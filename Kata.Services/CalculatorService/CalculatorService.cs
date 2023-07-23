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

        return validNumbers.Sum();
    }

    private IEnumerable<int> GetValidatedNumbers(IEnumerable<int> numbers)
    {
        var negativeNumbers = numbers.Where(x => x < 0);

        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }

        return numbers.Where(x => x <= 1000);
    }
}
