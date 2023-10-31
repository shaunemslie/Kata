namespace Kata.Helpers;
public interface IStringReaderWrapper
{
    int Peek();
    string ReadLine();
    string ReadToEnd();
    string ReadBlockBufferResult(int index, int count);
}
