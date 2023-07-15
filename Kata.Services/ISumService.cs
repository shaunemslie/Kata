namespace Kata.Services
{
    public interface ISumService
    {
        (List<int>, List<int>, int) GetNegativesAndSum(List<int> numbers);
    }
}
