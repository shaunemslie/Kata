namespace Kata.Helpers;
public interface ILimitValidator
{
    void ValidateWithinLimit(int[] numbers, Predicate<int> outsideLimitMatch, string exceptionMessage);
}
