namespace Kata.Services;

public class SumService : ISumService
{
    public List<int> GetNegatives(List<int> numbers)
    {
        return numbers.Where(x => x < 0).ToList();
    }

    public List<int> GetValidNumbers(List<int> numbers)
    {
        return numbers.Where(x => x <= 1000).ToList();
    }

    public int Sum(List<int> numbers)
    {
        return numbers.Sum();
    }
}
