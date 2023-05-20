using Benchmark.Services;

using Benchmark.Services.Interfaces;
using System.Globalization;

namespace Benchmark.Services
{

    
    public class StringCalculationService : IStringCalculationService
    {
        private readonly ISplitter _splitter;

        public StringCalculationService(ISplitter splitter)
        {
            _splitter = splitter;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            var numbersArray = _splitter.Split(numbers);
            var runningTotal = 0;

            foreach (var number in numbersArray)
            {
                if (int.TryParse(number, out var convertedNumber))
                {
                    runningTotal += convertedNumber;
                }
            }

            return runningTotal;
        }
    }
}

 
