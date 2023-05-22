using Benchmark.Services;

using Benchmark.Services.Interfaces;
using System.Globalization;
using System.Runtime;

namespace Benchmark.Services
{

    
    public class StringCalculationService : IStringCalculationService
    {
        /// <summary>
        /// final add function, require DI of INumberParser
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="numberParser"></param>
        /// <returns></returns>
        public int Add(string numbers, INumberParser numberParser)
        {
            var numbersArray = numberParser.ParseNumbers(numbers);
            var runningTotal = 0;

            foreach (var number in numbersArray)
            {
                runningTotal += number;
            }

            return runningTotal;
        }

        /// <summary>
        /// The initial Add class from steps 1 and 2
        /// included for discussion
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int Add(string numbers)
        {
            var runningTotal = 0;
            if (numbers == "")
                return 0;
            
            //if no comma return int of numbers if possible, else 0
            if (!numbers.Contains(','))
            {
                //Integer to account for negative values
                int.TryParse(numbers, NumberStyles.Integer, null, out runningTotal);
                return runningTotal;
            }
            //max length of array ~2billion

            var numbersArray = numbers.Split(',');

            foreach (var stringNumber in numbersArray)
            {
                int intNumber = 0;
                int.TryParse(stringNumber, NumberStyles.Integer, null, out intNumber);
                runningTotal += intNumber;
            }

            return runningTotal;
        }


     
    }
}

 
