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

    public int[] ParseNumbersFromInput(
        string input,
        string DelimiterSeperatorsDefinitionIndicators,
        string DelimitersDefinitionIndicator,
        HashSet<string> defaultDelimiters,
        HashSet<char> defaultSeparators)
    {
        var separators = defaultSeparators;

        if (input.StartsWith(DelimiterSeperatorsDefinitionIndicators.First()))
        {
            var extractedSeparators = ExtractDelimiterSeperators(input, DelimiterSeperatorsDefinitionIndicators);
            separators = extractedSeparators.ToHashSet();
        }

        var delimiters = defaultDelimiters;

        if (input.StartsWith(DelimitersDefinitionIndicator))
        {
            var extractedDelimiters = ExtractDelimiters(input, DelimitersDefinitionIndicator, separators);
            delimiters.UnionWith(extractedDelimiters);
        }

        var parsedNumbers = ExtractParsedNumbersAndCharacters(delimiters);

        return parsedNumbers;
    }

    private IEnumerable<char> ExtractDelimiterSeperators(string input, IEnumerable<char> DelimiterSeperatorsDefinitionIndicators)
    {
        var delimiterSeperatorsDefinition = _stringReaderWrapper.ReadBlockBufferResult(0, 3);

        var delimiterSeperators = input.Split(
            DelimiterSeperatorsDefinitionIndicators.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );
        var parsedSeperators = Array.ConvertAll(delimiterSeperators, Convert.ToChar);

        return parsedSeperators;
    }

    private IEnumerable<string> ExtractDelimiters(string input, string DelimiterDefinitionIndicator, IEnumerable<char> delimiterSeperators)
    {
        var delimitersInline = _stringReaderWrapper.ReadLine();

        var delimiters = input.Split(
            delimiterSeperators.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }

    private int[] ExtractParsedNumbersAndCharacters(IEnumerable<string> delimiters)
    {
        var inputLessDefinitions = _stringReaderWrapper.ReadToEnd();

        var characters = inputLessDefinitions.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );
        var parsedNumbers = new int[characters.Length];

        foreach (var character in characters)
            parsedNumbers.Append(ParseCharacter(character));

        return parsedNumbers;
    }

    private int ParseCharacter(string character)
    {
        if (int.TryParse(character, out var parsedNumber))
            return parsedNumber;

        if (Character.TryParse(character, out int parsedCharacter))
            return parsedCharacter;

        return 0;
    }
}
