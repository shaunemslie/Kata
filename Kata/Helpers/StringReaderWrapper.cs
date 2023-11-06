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

    public int Peek()
    {
        return (int)_stringReader.Peek();
    }

    public int Read()
    {
        return _stringReader.Read();
    }

    public string ReadLine()
    {
        return _stringReader.ReadLine();
    }

    public string ReadToEnd()
    {
        return _stringReader.ReadToEnd();
    }

    public char[] ReadBlockBufferResult(int index, int count)
    {
        var bufferSize = count - index;
        var buffer = new char[bufferSize];
        _stringReader.ReadBlock(buffer, index, count);

        return buffer;
    }
}
