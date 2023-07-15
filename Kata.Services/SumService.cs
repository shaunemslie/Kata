namespace Kata.Services;

public class SumService : ISumService
{
    public (List<int>, List<int>) GetNegativesAndValidNumbers(List<int> numbers)
    {
        var negatives = GetNegatives(numbers);
        var validNumbers = GetValidNumbers(numbers);

        return (negatives, validNumbers);
    }

    public List<int> GetNegatives(List<int> numbers)
    {
        return numbers.Where(x => x < 0).ToList();
    }

    public List<int> GetValidNumbers(List<int> numbers)
    {
        return numbers.Where(x => x <= 1000).ToList();
    }
}
