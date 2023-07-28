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

        var parsedNumbers = _readerService.GetParsedNumbersFromInput(numbers);
        var validNumbers = GetValidatedNumbers(parsedNumbers);
        var sum = validNumbers.Sum();

        return sum;
    }

    private IEnumerable<int> GetValidatedNumbers(IEnumerable<int> numbers)
    {
        var negativeNumbers = numbers.Where(x => x < 0);

        if (negativeNumbers.Any())
        {
            var negativeNumbersList = string.Join(",", negativeNumbers);
            throw new Exception($"Negatives not allowed: {negativeNumbersList}");
        }

        return numbers.Where(x => x <= 1000);
    }
}
