
namespace Benchmark.Services.Interfaces
{
    public interface IStringCalculationService
    {
        public int Add(string numbers);
        public int Add(string numbers, INumberParser parser);
        

    }
}
