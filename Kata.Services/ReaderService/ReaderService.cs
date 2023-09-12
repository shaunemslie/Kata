namespace Kata.Services;

public class ReaderService : IReaderService
{
    public int[] GetParsedNumbersFromInput(string numbers)
    {
        const string DelimiterLinePrefix = "//";
        var reader = new StringReader(numbers);
        var delimiters = new List<string> { ",", "\n" };

        if (numbers.StartsWith(DelimiterLinePrefix))
        {
            var delimiterLine = reader.ReadLine()!;
            var extractedDelimiters = GetExtractedDelimiters(delimiterLine);

            delimiters.AddRange(extractedDelimiters);
        }

        var inputLessDelimiterLine = reader.ReadToEnd();
        var parsedNumbers = GetExtractedAndParsedNumbers(inputLessDelimiterLine, delimiters);

        return parsedNumbers;
    }

    private string[] GetExtractedDelimiters(string delimiterLine)
    {
        var delimiterLineLessPrefix = delimiterLine.Substring(2);
        var hasMultipleDelimiters = delimiterLineLessPrefix.Contains('[');

        if (!hasMultipleDelimiters)
        {
            return new[] { delimiterLineLessPrefix };
        }

        var delimiters = delimiterLineLessPrefix.Split(
            new[] { '[', ']' },
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }

    private int[] GetExtractedAndParsedNumbers(string numbers, IEnumerable<string> delimiters)
    {
        var numbersLessDelimiters = numbers.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );
        var parsedNumbers = Array.ConvertAll<string, int>(numbersLessDelimiters, int.Parse);

        return parsedNumbers;
    }
}

