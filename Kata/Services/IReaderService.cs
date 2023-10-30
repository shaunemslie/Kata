namespace Kata.Services;
public interface IReaderService
{
    IEnumerable<int> ParseNumbersFromInput(
        string input,
        string DelimiterSeperatorsDefinitionIndicators,
        string DelimitersDefinitionIndicator,
        HashSet<string> defaultDelimiters,
        HashSet<char> defaultSeparators
    );
}
