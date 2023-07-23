namespace Kata.Services
{
    public interface IReaderService
    {
        IEnumerable<int> GetParsedNumbersFromInput(string input);
    }
}
