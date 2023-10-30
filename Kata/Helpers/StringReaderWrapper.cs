namespace Kata.Helpers;
public class StringReaderWrapper : IStringReaderWrapper
{
    private readonly StringReader _stringReader;

    public StringReaderWrapper(StringReader stringReader)
    {
        _stringReader = stringReader;
    }

    ~StringReaderWrapper()
    {
        _stringReader.Close();
        _stringReader.Dispose();
    }

    public string ReadLine()
    {
        return _stringReader.ReadLine();
    }

    public string ReadToEnd()
    {
        return _stringReader.ReadToEnd();
    }

    public string ReadBlockBufferResult(int index, int count)
    {
        var bufferSize = count - index + 1;
        var buffer = new char[bufferSize];
        _stringReader.ReadBlock(buffer, index, count);

        return buffer.ToString();
    }
}
