namespace Kata.Services;

public class ParserService : IParserService
{
    public IEnumerable<int> GetParsedNumbersFromInput(string input)
    {
        var inputModel = GetPopulatedInputModel(input);
        var delimiters = GetDefaultAndCustomDelimiters(inputModel.DelimiterLine);
        var numbers = GetExtractedParsedNumbers(inputModel.RemainingInput, delimiters);

        return numbers;
    }

    public InputModel GetPopulatedInputModel(string input)
    {
        if (!input.StartsWith("//"))
        {
            return GetInputModel(null, input);
        }

        var inputNewLines = input.Split('\n');
        var delimiterLine = inputNewLines.First().Replace("//", string.Empty);
        var inputLessDelimiterLine = string.Join('\n', inputNewLines.Skip(1));

        return GetInputModel(delimiterLine, inputLessDelimiterLine);
    }

    public IEnumerable<string> GetDefaultAndCustomDelimiters(string delimiterLine)
    {
        var defaultDelimiters = new string[] { ",", "\n" };

        if (string.IsNullOrEmpty(delimiterLine))
        {
            return defaultDelimiters;
        }

        if (!delimiterLine.Contains('['))
        {
            return defaultDelimiters.Append(delimiterLine);
        }

        var extractedDelimiters = GetDelimitersFromDelimiterLine(delimiterLine);
        var delimiters = defaultDelimiters.Concat(extractedDelimiters);

        return delimiters;
    }

    public IEnumerable<int> GetExtractedParsedNumbers(string remainingInput, IEnumerable<string> delimiters)
    {
        var numbers = remainingInput.Split(
            delimiters.ToArray(),
            StringSplitOptions.RemoveEmptyEntries
        );
        var parsedNumbers = numbers.Select(x => int.Parse(x));

        return parsedNumbers;
    }

    private InputModel GetInputModel(string delimiterLine, string remainingInput)
    {
        return new InputModel
        {
            DelimiterLine = delimiterLine,
            RemainingInput = remainingInput
        };
    }

    private IEnumerable<string> GetDelimitersFromDelimiterLine(string delimiterLine)
    {
        var delimiters = delimiterLine.Split(
            new char[] { '[', ']' },
            StringSplitOptions.RemoveEmptyEntries
        );

        return delimiters;
    }
}
