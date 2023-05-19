using Benchmark.Services.Helpers;
using Benchmark.Services.Interfaces;

namespace Benchmark.Services
{
    public class StringCalculationService : IStringCalculationService
    {
        public override int Add(string numbers)
        {
            var runningTotal = 0;
            if (numbers == "")
                return 0;

            if (!numbers.Contains(','))
            {
                return numbers.TryConvertStringToInt32();
            }
            //max length of array ~2billion
            var numbersArray = numbers.Split(',');

            foreach (var number in numbersArray)
            {
                runningTotal += number.TryConvertStringToInt32();
            }

            return runningTotal;
        }
    }
}
