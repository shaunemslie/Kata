namespace Kata.Services
{
    public interface IParserService
    {
        (List<string>, List<int>) ParseDelimitersAndNumbers(string userInput);
    }
}
