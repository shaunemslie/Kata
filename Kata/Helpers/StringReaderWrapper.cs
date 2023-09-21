namespace Kata.Helpers;
public class StringReaderWrapper : IStringReaderWrapper
{
    private readonly StringReader _stringReader;

    public StringReaderWrapper(StringReader stringReader)
    {
        _stringReader = stringReader;
    }

    public string ReadLine()
    {
        return _stringReader.ReadLine();
    }

    public string ReadToEnd()
    {
        return _stringReader.ReadToEnd();
    }
}
