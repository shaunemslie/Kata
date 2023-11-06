namespace Kata.Helpers;
public interface IStringReaderWrapper
{
    int Peek();
    int Read();
    string ReadLine();
    string ReadToEnd();
    char[] ReadBlockBufferResult(int index, int count);
}
