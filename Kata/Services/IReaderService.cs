namespace Kata.Services;
public interface IReaderService
{
    int[] ParseNumbersFromInput(string numbers, string delimiterLinePrefix, List<string> delimiters);
}
