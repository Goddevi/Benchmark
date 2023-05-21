using Benchmark.Services;

using Benchmark.Services.Interfaces;
using System.Globalization;

namespace Benchmark.Services
{
    public class DefaultNumberParser : INumberParser
    {
        public virtual int[] ParseNumbers(string input)
        {
            if(input == null)
                return new int[0]; 
            var parsedNumbers = input.Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.TryParse(x, NumberStyles.Integer, null, out int result) ? result : 0)
                        .ToArray();
            HandleNegativeNumbers(parsedNumbers);
            return parsedNumbers;  

        }


        protected virtual void HandleNegativeNumbers(int[] numbers)
        {
            var negativeNumbers = numbers.Where(n => n < 0).ToArray();
            if (negativeNumbers.Length > 0)
            {
                throw new ArgumentException($"Negatives are not allowed: {string.Join(", ", negativeNumbers)}");
            }
        }
    }

}


