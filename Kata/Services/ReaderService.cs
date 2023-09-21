using Kata.Helpers;

namespace Kata.Services;
public class ReaderService : IReaderService
{
    private readonly IStringReaderWrapper _stringReaderWrapper;

    public ReaderService(IStringReaderWrapper stringReaderWrapper)
    {
        _stringReaderWrapper = stringReaderWrapper;
    }

    public int[] GetParsedSummandsFromInput(string numbers)
    {
        const string DelimiterLinePrefix = "//";
        var delimiters = new List<string> { ",", "\n" };

        if (numbers.StartsWith(DelimiterLinePrefix))
        {
            var delimitersInline = _stringReaderWrapper.ReadLine();
            var extractedDelimiters = GetExtractedDelimiters(delimitersInline);

            delimiters.AddRange(extractedDelimiters);
        }

        var inputLessDelimiterLine = _stringReaderWrapper.ReadToEnd();
        var parsedSummands = GetExtractedAndParsedSummands(inputLessDelimiterLine, delimiters);

        return parsedSummands;
    }

    private string[] GetExtractedDelimiters(string delimitersInline)
    {
        var delimitersInlineLessPrefix = delimitersInline.Substring(2);
        var hasMultipleDelimiters = delimitersInlineLessPrefix.Contains('[');

        if (!hasMultipleDelimiters)
        {
            return new string[] { delimitersInlineLessPrefix };
        }

        var delimiters = delimitersInlineLessPrefix.Split(
            new char[] { '[', ']' },
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }

    private int[] GetExtractedAndParsedSummands(string inputLessDelimiterLine, IEnumerable<string> delimiters)
    {
        var summands = inputLessDelimiterLine.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );
        var parsedSummands = Array.ConvertAll<string, int>(summands, int.Parse);

        return parsedSummands;
    }
}
