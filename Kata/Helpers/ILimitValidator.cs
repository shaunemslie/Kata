namespace Kata.Helpers;
public interface ILimitValidator
{
    void ValidateWithinLimit(IEnumerable<int> numbers, string ExceptionMessage, Predicate<int> outsideLimitMatch);
}
