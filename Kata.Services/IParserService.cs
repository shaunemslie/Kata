namespace Kata.Services
{
    public interface IParserService
    {
        (List<string>, List<int>) ParseDelimitersAndNumbers(string userInput);
        List<string> GetDelimitersFromUserInput(string userInput, bool hasDelimiters);
        List<int> GetNumbersFromUserInput(string userInput, List<string> delimiters, bool hasDelimiters);
    }
}
