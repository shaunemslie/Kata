namespace Kata.Services;

public class ReaderService : IReaderService
{
    public IEnumerable<int> GetParsedNumbersFromInput(string input)
    {
        var reader = new StringReader(input);
        var delimiters = new List<string> { ",", "\n" };

        if (input.StartsWith("//"))
        {
            var extractedDelimiters = GetExtractedDelimiters(reader.ReadLine());
            delimiters.AddRange(extractedDelimiters);
        }

        var numbers = GetExtractedAndParsedNumbers(reader.ReadToEnd(), delimiters);

        return numbers;
    }

    private IEnumerable<string> GetExtractedDelimiters(string delimiterLine)
    {
        var delimiterLineLessPrefix = delimiterLine.Replace("//", string.Empty);

        if (!delimiterLineLessPrefix.Contains("["))
        {
            return new[] { delimiterLineLessPrefix };
        }

        var delimiters = delimiterLineLessPrefix.Split(
            new[] { "[", "]" },
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }

    private IEnumerable<int> GetExtractedAndParsedNumbers(string input, List<string> delimiters)
    {
        var numbers = input.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );

        return numbers.Select(int.Parse);
    }
}
