namespace Kata.Services
{
    public interface IParserService
    {
        IEnumerable<int> GetParsedNumbersFromInput(string input);
    }
}
