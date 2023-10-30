using System.Runtime.InteropServices;
using Kata.Helpers;

namespace Kata.Services;
public class ReaderService : IReaderService
{
    private readonly IStringReaderWrapper _stringReaderWrapper;

    public ReaderService(IStringReaderWrapper stringReaderWrapper)
    {
        _stringReaderWrapper = stringReaderWrapper;
    }

    public int[] ParseNumbersFromInput(string numbers, string delimiterLinePrefix, List<string> delimiters)
    {
        if (numbers.StartsWith(delimiterLinePrefix))
        {
            var delimitersInline = _stringReaderWrapper.ReadLine();
            var extractedDelimiters = ExtractDelimiters(delimitersInline);

            delimiters.AddRange(extractedDelimiters);
        }

        var inputLessDelimiterLine = _stringReaderWrapper.ReadToEnd();
        var parsedNumbers = ExtractAndParseNumbers(inputLessDelimiterLine, delimiters);

        return parsedNumbers;
    }

    // TODO:
    private string[] ExtractDelimiters(string delimitersInline)
    {
        var delimitersInlineLessPrefix = delimitersInline.Substring(2);
        var hasMultipleDelimiters = delimitersInlineLessPrefix.Contains('[');

        if (!hasMultipleDelimiters)
            return new string[] { delimitersInlineLessPrefix };

        var delimiters = delimitersInlineLessPrefix.Split(
            new char[] { '[', ']' },
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }

    private int[] ExtractAndParseNumbers(string inputLessDelimiterLine, IEnumerable<string> delimiters)
    {
        var characters = inputLessDelimiterLine.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );

        var parsedNumbers = Array.ConvertAll(characters, int.Parse);

        return parsedNumbers;
    }
}
