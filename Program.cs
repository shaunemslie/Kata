class Program
{
    private readonly CalculatorService _calculatorService;

    static void Main(string[] args)
    {
        var p = new Program();
        var reader = new StreamReader("TestFile.txt");
        var file = reader.ReadToEnd();
        var sum = p.Add(file);

        Console.WriteLine("Enter your summands & delimiters:");
    }
}
