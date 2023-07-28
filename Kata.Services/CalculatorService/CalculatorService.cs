namespace Kata.Services;

public class CalculatorService : ICalculatorService
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }
    }
}
