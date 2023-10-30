using Kata.Helpers;
using Kata.Models;

namespace Kata.Services;
public class ReaderService : IReaderService
{
    private readonly IStringReaderWrapper _stringReaderWrapper;

    public ReaderService(IStringReaderWrapper stringReaderWrapper)
    {
        _stringReaderWrapper = stringReaderWrapper;
    }

    public IEnumerable<int> ParseNumbersFromInput(
        string input,
        string DelimiterSeperatorsDefinitionIndicators,
        string DelimitersDefinitionIndicator,
        HashSet<string> defaultDelimiters,
        HashSet<char> defaultSeparators)
    {
        var separators = defaultSeparators;

        if (input.StartsWith(DelimiterSeperatorsDefinitionIndicators.First()))
        {
            var extractedSeparators = ExtractDelimiterSeperators(DelimiterSeperatorsDefinitionIndicators);
            separators = extractedSeparators.ToHashSet();
        }

        var delimiters = defaultDelimiters;

        if (input.StartsWith(DelimitersDefinitionIndicator))
        {
            var extractedDelimiters = ExtractDelimiters(DelimitersDefinitionIndicator, separators);
            delimiters.UnionWith(extractedDelimiters);
        }

        var parsedNumbers = ExtractParsedNumbersAndCharacters(delimiters);

        return parsedNumbers;
    }

    private IEnumerable<char> ExtractDelimiterSeperators(IEnumerable<char> DelimiterSeperatorsDefinitionIndicators)
    {
        var delimiterSeperatorsDefinition = _stringReaderWrapper.ReadBlockBufferResult(0, 3);

        var delimiterSeperators = delimiterSeperatorsDefinition.Split(
            DelimiterSeperatorsDefinitionIndicators.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );
        var parsedSeperators = Array.ConvertAll(delimiterSeperators, Convert.ToChar);

        return parsedSeperators;
    }

    private IEnumerable<string> ExtractDelimiters(string DelimiterDefinitionIndicator, IEnumerable<char> delimiterSeperators)
    {
        _stringReaderWrapper.ReadBlockBufferResult(0, DelimiterDefinitionIndicator.Length - 1);
        var delimitersInline = _stringReaderWrapper.ReadLine();

        var delimiters = delimitersInline.Split(
            delimiterSeperators.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }

    private IEnumerable<int> ExtractParsedNumbersAndCharacters(IEnumerable<string> delimiters)
    {
        var inputLessDefinitions = _stringReaderWrapper.ReadToEnd();

        var entries = inputLessDefinitions.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );
        var parsedNumbers = new List<int> { };

        foreach (var entry in entries)
        {
            var parsedNumber = ParseCharacter(entry);
            parsedNumbers.Add(parsedNumber);
        }

        return parsedNumbers;
    }

    private int ParseCharacter(string entry)
    {
        if (int.TryParse(entry, out int parsedNumber))
            return parsedNumber;

        if (Character.TryParse(entry, out int parsedCharacter))
            return parsedCharacter;

        return 0;
    }
}
