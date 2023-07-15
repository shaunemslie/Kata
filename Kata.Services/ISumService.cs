namespace Kata.Services
{
    public interface ISumService
    {
        (List<int>, List<int>) GetNegativesAndValidNumbers(List<int> numbers);
    }
}
