namespace Kata.Services;

public class SumService : ISumService
{
    public (List<int>, List<int>, int) GetNegativesAndSum(List<int> numbers)
    {
        var negatives = GetNegatives(numbers);
        var validNumbers = GetValidNumbers(numbers);
        var sum = Sum(validNumbers);

        return (negatives, validNumbers, sum);
    }

    private List<int> GetNegatives(List<int> numbers)
    {
        return numbers.Where(x => x < 0).ToList();
    }

    private List<int> GetValidNumbers(List<int> numbers)
    {
        return numbers.Where(x => x <= 1000).ToList();
    }

    private int Sum(List<int> numbers)
    {
        return numbers.Sum();
    }
}
