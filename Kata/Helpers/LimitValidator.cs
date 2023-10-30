namespace Kata.Helpers;
public class LimitValidator : ILimitValidator
{
    public void ValidateWithinLimit(IEnumerable<int> numbers, string ExceptionMessage, Predicate<int> outsideLimitMatch)
    {
        var numbersOutsideLimit = Array.FindAll(numbers.ToArray(), outsideLimitMatch);

        if (numbersOutsideLimit.Length != 0)
            throw new LimitException(ExceptionMessage, numbersOutsideLimit);
    }
}

public class LimitException : Exception
{
    private int[] _numbers;
    public string GetItems
    {
        get => string.Join(',', _numbers);
    }

    public LimitException() { }

    public LimitException(string message) : base(message) { }

    public LimitException(string message, int[] numbers) : this(message)
    {
        _numbers = numbers;
    }
}
