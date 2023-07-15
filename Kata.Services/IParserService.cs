namespace Kata.Services
{
    public interface IParserService
    {
        (List<string>, List<int>) ParseDelimitersAndNumbers(string userInput);
        List<string> GetDelimitersFromUserInput(string userInput);
        List<int> GetNumbersFromUserInput(string userInput, List<string> delimiters);
    }
}
