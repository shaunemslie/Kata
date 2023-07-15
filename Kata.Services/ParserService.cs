namespace Kata.Services;

public class ParserService : IParserService
{
    public List<string> GetDelimitersFromUserInput(string userInput)
    {
        var delimiters = new List<string> { ",", "\n" };

        if (userInput.StartsWith("//"))
        {
            var customizedDelimiters = GetDelimitersFromFirstLine(userInput);
            delimiters.AddRange(customizedDelimiters);
        }

        return delimiters;
    }

    public List<int> GetNumbersFromUserInput(string userInput, List<string> delimiters)
    {
        if (userInput.StartsWith("//"))
        {
            var userInputLines = userInput.Split('\n');
            userInput = string.Join(',', userInputLines.Skip(1));
        }

        var delimitedNumbers = userInput.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        return ParseToNumbers(delimitedNumbers.ToList());
    }

    public List<int> ParseToNumbers(List<string> input)
    {
        return input.Select(int.Parse).ToList();
    }

    private List<string> GetDelimitersFromFirstLine(string userInput)
    {
        var delimiters = userInput.Split(
            new string[] { "[", "]", "//" },
            StringSplitOptions.RemoveEmptyEntries
        ).ToList();

        return delimiters;
    }
}
