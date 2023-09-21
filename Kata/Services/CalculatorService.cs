namespace Kata.Services;
public class CalculatorService : ICalculatorService
{
    public int[] GetValidatedSummands(int[] summandsToCheck)
    {
        var negativeNumbers = Array.FindAll(summandsToCheck, number => number < 0);

        if (negativeNumbers?.Length > 0)
        {
            var negativeNumberExceptionList = string.Join(',', negativeNumbers);
            var negativeNumbersExceptionMessage = $"Negatives not allowed: {negativeNumberExceptionList}";

            throw new Exception(negativeNumbersExceptionMessage);
        }

        var validSummands = Array.FindAll(summandsToCheck, number => number <= 1000);

        return validSummands;
    }

    public int Sum(int[] summands)
    {
        var sum = 0;
        foreach (var addend in summands)
        {
            sum += addend;
        }

        return sum;
    }
}
