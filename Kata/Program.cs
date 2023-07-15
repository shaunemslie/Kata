using Kata.Services;

namespace Kata;

public class Program
{
    private IParserService _parserService = new ParserService();
    private ISumService _sumService = new SumService();

    public static void Main(string[] args)
    {
        var p = new Program();
        var reader = new StreamReader("TestFile.txt");
        var file = reader.ReadToEnd();
        var sum = p.Add(file);

        Console.WriteLine(sum);
    }

    private int Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        var delimiters = _parserService.GetDelimitersFromUserInput(numbers);
        var parsedNumbers = _parserService.GetNumbersFromUserInput(numbers, delimiters);
        var negativeNumbers = _sumService.GetNegatives(parsedNumbers);

        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed: {string.Join(',', negativeNumbers)}");
        }

        var validNumbers = _sumService.GetValidNumbers(parsedNumbers);
        var sum = _sumService.Sum(validNumbers);

        return sum;
    }
}
