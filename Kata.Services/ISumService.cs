namespace Kata.Services
{
    public interface ISumService
    {
        List<int> GetNegatives(List<int> numbers);
        List<int> GetValidNumbers(List<int> numbers);
        int Sum(List<int> numbers);
    }
}
