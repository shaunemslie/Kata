namespace Kata.Helpers;
public interface ILimitValidator
{
    void ValidateWithinLimit(int[] numbers, string ExceptionMessage, Predicate<int> outsideLimitMatch);
}
