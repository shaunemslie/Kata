namespace Kata.Services;

public class CalculatorService : ICalculatorService
{
    private readonly IParserService _parserService;

    public CalculatorService(IParserService parserService)
    {
        _parserService = parserService;
    }

    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        var parsedNumbers = _parserService.GetParsedNumbersFromInput(numbers);
        var validNumbers = GetValidatedNumbers(parsedNumbers);

        return validNumbers.Sum();
    }

    public IEnumerable<int> GetValidatedNumbers(IEnumerable<int> numbers)
    {
        var negativeNumbers = numbers.Where(x => x < 0);

        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed: {string.Join(",", negativeNumbers)}");
        }

        return numbers.Where(x => x <= 1000);
    }
}
