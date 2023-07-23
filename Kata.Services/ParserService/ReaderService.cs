namespace Kata.Services;

public class ReaderService : IReaderService
{
    public IEnumerable<int> GetParsedNumbersFromInput(string input)
    {
        var reader = new StringReader(input);
        var delimiters = GetDefaultAndExtractedDelimiters(reader.ReadLine());
        var numbers = GetExtractedAndParsedNumbers(reader.ReadToEnd(), delimiters);

        return numbers;
    }

    private IEnumerable<int> GetExtractedAndParsedNumbers(string input, IEnumerable<string> delimiters)
    {
        var numbers = input.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );

        return numbers.Select(int.Parse);
    }

    private IEnumerable<string> GetDefaultAndExtractedDelimiters(string delimiterLine)
    {
        var defaultDelimiters = new List<string> { ",", "\n" };

        if (string.IsNullOrWhiteSpace(delimiterLine) || !delimiterLine.StartsWith("//"))
        {
            return defaultDelimiters;
        }

        var extractedDelimiters = ExtractDelimiters(delimiterLine);
        var delimiters = defaultDelimiters.Concat(extractedDelimiters);

        return delimiters;
    }

    private IEnumerable<string> ExtractDelimiters(string delimiterLine)
    {
        delimiterLine = delimiterLine.Replace("//", string.Empty);
        var delimiters = delimiterLine.Split(
            new[] { "[", "]" },
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }
}
