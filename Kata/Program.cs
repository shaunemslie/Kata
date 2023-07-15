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

        var (delimiters, parsedNumbers) = _parserService.ParseDelimitersAndNumbers(numbers);
        var (negativeNumbers, validNumbers) = _sumService.GetNegativesAndValidNumbers(parsedNumbers);

        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed: {string.Join(',', negativeNumbers)}");
        }

        return validNumbers.Sum();
    }
}
