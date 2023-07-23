namespace Kata.Services;

public class ParserService : IParserService
{
    public (List<string>, List<int>) ParseDelimitersAndNumbers(string userInput)
    {
        var hasDelimiters = userInput.StartsWith("//");
        var delimiters = GetDelimitersFromUserInput(userInput, hasDelimiters);
        var numbers = GetNumbersFromUserInput(userInput, delimiters, hasDelimiters);

        return (delimiters, numbers);
    }

    public List<string> GetDelimitersFromUserInput(string userInput, bool hasDelimiters)
    {
        var delimiters = new List<string> { ",", "\n" };

        if (hasDelimiters)
        {
            var userInputFirstLine = userInput.Split('\n').First();
            var customizedDelimiters = GetDelimitersFromFirstLine(userInputFirstLine);
            delimiters.AddRange(customizedDelimiters);
        }

        return delimiters;
    }

    public List<int> GetNumbersFromUserInput(string userInput, List<string> delimiters, bool hasDelimiters)
    {
        if (hasDelimiters)
        {
            var userInputLines = userInput.Split('\n');
            userInput = string.Join(',', userInputLines.Skip(1));
        }

        var delimitedNumbers = userInput.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        var parsedNumbers = ParseToNumbers(delimitedNumbers.ToList());

        return parsedNumbers;
    }

    private List<string> GetDelimitersFromFirstLine(string userInputFirstLine)
    {
        if (!userInputFirstLine.Contains('['))
        {
            var length = userInputFirstLine.Length;
            var singleDelimiter = userInputFirstLine.Substring(2, length - 2);
            var singleDelimiterList = new List<string> { singleDelimiter };

            return singleDelimiterList;
        }

        var delimiters = userInputFirstLine.Split(
            new string[] { "[", "]", "//" },
            StringSplitOptions.RemoveEmptyEntries
        ).ToList();

        return delimiters;
    }

    private List<int> ParseToNumbers(List<string> input)
    {
        return input.Select(int.Parse).ToList();
    }
}
