namespace Kata.Services;

public class ReaderService : IReaderService
{
    public IEnumerable<int> GetParsedNumbersFromInput(string input)
    {
        var reader = new StringReader(input);
        var delimiters = new List<string> { ",", "\n" };
        var delimiterLinePrefix = "//";

        if (input.StartsWith(delimiterLinePrefix))
        {
            var delimiterLine = reader.ReadLine();
            var extractedDelimiters = GetExtractedDelimiters(delimiterLine!);

            delimiters.AddRange(extractedDelimiters);
        }

        var inputLessDelimiterLine = reader.ReadToEnd();
        var numbers = GetExtractedAndParsedNumbers(inputLessDelimiterLine, delimiters);

        return numbers;
    }

    private IEnumerable<string> GetExtractedDelimiters(string delimiterLine)
    {
        var delimiterLineLessPrefix = delimiterLine.Substring(2);

        if (!delimiterLineLessPrefix.Contains('['))
        {
            return new[] { delimiterLineLessPrefix };
        }

        var delimiters = delimiterLineLessPrefix.Split(
            new[] { '[', ']' },
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

