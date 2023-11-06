namespace Kata.Services;
public class CalculatorService : ICalculatorService
{
    public int Sum(IEnumerable<int> summands)
    {
        var sum = 0;

        foreach (var addend in summands)
            if (int.IsPositive(addend))
                sum += addend;
            else
                sum -= addend;

        return sum;
    }
}
