namespace Kata.Services
{
    public interface IParserService
    {
        List<string> GetDelimitersFromUserInput(string userInput);
        List<int> GetNumbersFromUserInput(string userInput, List<string> delimiters);
        List<int> ParseToNumbers(List<string> input);
    }
}
