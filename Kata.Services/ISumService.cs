namespace Kata.Services
{
    public interface ISumService
    {
        (List<int>, List<int>) GetNegativesAndValidNumbers(List<int> numbers);
        List<int> GetNegatives(List<int> numbers);
        List<int> GetValidNumbers(List<int> numbers);
    }
}
