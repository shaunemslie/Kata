namespace Kata.Services;

public class ParserService : IParserService
{
    public (List<string>, List<int>) ParseDelimitersAndNumbers(string userInput)
    {
        var delimiters = GetDelimitersFromUserInput(userInput);
        var numbers = GetNumbersFromUserInput(userInput, delimiters);

        return (delimiters, numbers);
    }

    private List<string> GetDelimitersFromUserInput(string userInput)
    {
        var delimiters = new List<string> { ",", "\n" };

        if (userInput.StartsWith("//"))
        {
            var userInputFirstLine = userInput.Split('\n').First();
            var customizedDelimiters = GetDelimitersFromFirstLine(userInputFirstLine);

            delimiters.AddRange(customizedDelimiters);
        }

        return delimiters;
    }

    private List<int> GetNumbersFromUserInput(string userInput, List<string> delimiters)
    {
        if (userInput.StartsWith("//"))
        {
            var userInputLines = userInput.Split('\n');
            userInput = string.Join(',', userInputLines.Skip(1));
        }

        var delimitedNumbers = userInput.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        return ParseToNumbers(delimitedNumbers.ToList());
    }

    private List<string> GetDelimitersFromFirstLine(string userInput)
    {
        if (userInputFirstLine.Contains('[') && userInputFirstLine.Contains(']'))
        {
            var delimiters = userInputFirstLine.Split(
                new string[] { "[", "]", "//" },
                StringSplitOptions.RemoveEmptyEntries
            ).ToList();

            return delimiters;
        }

        var length = userInputFirstLine.Length;
        var singleDelimiter = userInputFirstLine.Substring(2, length - 2);

        return new List<string> { singleDelimiter };
    }

    private List<int> ParseToNumbers(List<string> input)
    {
        return input.Select(int.Parse).ToList();
    }
}
