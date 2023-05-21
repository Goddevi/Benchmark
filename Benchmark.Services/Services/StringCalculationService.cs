using Benchmark.Services;

using Benchmark.Services.Interfaces;
using System.Globalization;
using System.Runtime;

namespace Benchmark.Services
{

    
    public class StringCalculationService : IStringCalculationService
    {
        public int Add(string numbers)
        {
            var runningTotal = 0;
            if (numbers == "")
                return 0;

            if (!numbers.Contains(','))
            {
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


      
        public int Add(string numbers, INumberParser numberParser)
        {
          
            var numbersArray = numberParser.ParseNumbers(numbers);
            var runningTotal = 0;

            foreach (var number in numbersArray)
            {              
                    runningTotal += number <=1000 ? number : 0;  
            }

            return runningTotal;
        }
    }
}

 
