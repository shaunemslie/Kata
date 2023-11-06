namespace Kata.Services;
public interface IReaderService
{
    IEnumerable<int> ReadAndParseInput(
        string input,
        string DelimitersDefinitionPrefix,
        string SeparatorsDefinitionClosure,
        List<char> separators,
        List<string> delimiters);
}
