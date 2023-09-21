namespace Kata.Services;
public interface ICalculatorService
{
    int[] GetValidatedSummands(int[] summandsToCheck);
    int Sum(int[] summands);
}
