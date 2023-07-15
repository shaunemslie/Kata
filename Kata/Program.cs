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

        p.Add(file);
    }

    private void Add(string numbers)
    {
        if (string.IsNullOrEmpty(numbers))
        {
            Console.WriteLine(0);
            return;
        }

        var (delimiters, parsedNumbers) = _parserService.ParseDelimitersAndNumbers(numbers);
        var (negativeNumbers, validNumbers, sum) = _sumService.GetNegativesAndSum(parsedNumbers);

        if (negativeNumbers.Any())
        {
            throw new Exception($"Negatives not allowed: {string.Join(',', negativeNumbers)}");
        }

        Console.WriteLine(sum);
    }
}
