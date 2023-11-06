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

    public IEnumerable<int> ReadAndParseInput(
        string input,
        string DelimitersDefinitionPrefix,
        string SeparatorsDefinitionClosure,
        List<char> separators,
        List<string> delimiters)
    {
        var sublengthDelimiterDefinition = input.IndexOf(DelimitersDefinitionPrefix);

        var extractedSeperators = ExtractSeparatorCharacters(SeparatorsDefinitionClosure.ToCharArray(), sublengthDelimiterDefinition);
        foreach (var separator in extractedSeperators)
            separators.Add(separator);

        var extractedDelimiters = ExtractDelimiters(DelimitersDefinitionPrefix, sublengthDelimiterDefinition, separators);
        foreach (var delimiter in extractedDelimiters)
            delimiters.Add(delimiter);

        var parsedNumbers = ExtractParsedEntries(delimiters);

        return parsedNumbers;
    }

    private IEnumerable<char> ExtractSeparatorCharacters(char[] SeparatorsDefinitionClosure, int separatorsDefinitionLength)
    {
        var shouldExtractSeparators = separatorsDefinitionLength == 4 &&
            _stringReaderWrapper.Peek() == (int)SeparatorsDefinitionClosure[0];

        if (!shouldExtractSeparators)
            return Array.Empty<char>();

        var separatorsDefinition = _stringReaderWrapper.ReadBlockBufferResult(0, SeparatorsDefinitionClosure.Length + separatorsDefinitionLength);

        var separators = separatorsDefinition.ToString().Split(
            SeparatorsDefinitionClosure,
            StringSplitOptions.RemoveEmptyEntries
        );

        return Array.ConvertAll(separators, Convert.ToChar);
    }

    private IEnumerable<string> ExtractDelimiters(string DelimitersDefinitionPrefix, int indexOfDelimiterDefinitionPrefix, IEnumerable<char> separators)
    {
        var shouldExtractDelimiters = indexOfDelimiterDefinitionPrefix >= 0;

        if (!shouldExtractDelimiters)
            return Array.Empty<string>();

        var delimitersDefinition = _stringReaderWrapper.ReadBlockBufferResult(0, DelimitersDefinitionPrefix.Length);
        var delimitersInline = _stringReaderWrapper.ReadLine();

        var delimiters = delimitersInline.Split(
            separators.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }

    private IEnumerable<int> ExtractParsedEntries(IEnumerable<string> delimiters)
    {
        var inputLessDefinitions = _stringReaderWrapper.ReadToEnd();
        var parsedNumbers = new List<int> { };

        var entries = inputLessDefinitions.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );

        foreach (var entry in entries)
            parsedNumbers.Add(ParseCharacter(entry));

        return parsedNumbers;
    }

    private int ParseCharacter(string entry)
    {
        Console.WriteLine(entry);
        if (int.TryParse(entry, out int parsedNumber))
            return parsedNumber;

        if (Enum.TryParse(entry, true, out Character parsedCharacter))
            return (int)parsedCharacter + 1;

        return 0;
    }
}
