using Kata.Services;

namespace Kata;
public class Calculator
{
    private readonly IReaderService _readerService;
    private readonly ICalculatorService _calculatorService;

    public Calculator(IReaderService readerService, ICalculatorService calculatorService)
    {
        _readerService = readerService;
        _calculatorService = calculatorService;
    }

    public int Add(string numbers)
    {
        // Could move this into the reader service and write a unit test surrounding this, since it is logic, however feels quite futile..
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        var parsedSummands = _readerService.GetParsedSummandsFromInput(numbers);
        var validSummands = _calculatorService.GetValidatedSummands(parsedSummands);

        return _calculatorService.Sum(validSummands);
    }
}
