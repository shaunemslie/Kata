namespace Kata.Helpers;
public interface IStringReaderWrapper
{
    string ReadLine();
    string ReadToEnd();
    string ReadBlockBufferResult(int index, int count);
}
