using Benchmark.Services;

using Benchmark.Services.Interfaces;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Benchmark.Services
{
    public class DefaultNumberParser : INumberParser
    {
        private const int LargeNumberLimit = 1000;

        public virtual int[] ParseNumbers(string input)
        {
            if (input == null)
                return new int[0];
            // Split the input string using the delimiters ("," and "\n")

            // Convert each string element to an integer using NumberStyles.Integer
            // and handle invalid values by assigning them the default value of 0
            var parsedNumbers = input.Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.TryParse(x, NumberStyles.Integer, null, out int result) ? result : 0)
                        .ToArray();

            return parsedNumbers;

        }

        /// <summary>
        /// method for handling negative numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <exception cref="ArgumentException"></exception>
        protected virtual void HandleNegativeNumbers(int[] numbers)
        {
            //Strip the negatives out for throwing in the error
            var negativeNumbers = numbers.Where(n => n < 0).ToArray();
            if (negativeNumbers.Length > 0)
            {
                //String interpolation for error messages
                throw new ArgumentException($"Negatives are not allowed: {string.Join(", ", negativeNumbers)}");
            }
        }

       /// <summary>
       /// method to limit size of numbers that can be added
       /// </summary>
       /// <param name="numbers"></param>
       /// <returns></returns>
        protected virtual int[] HandleLargeNumbers(int[] numbers)
        {
            //LargeNumberLimit defined at top
            return numbers.Where(x => x <= LargeNumberLimit).ToArray(); 
        }

        /// <summary>
        /// method for retrieval of delimiters
        /// </summary>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        protected virtual char[] HandlePotentialMultipleDelimiters(string delimiter)
        {
            return delimiter.ToCharArray();
        }
    }

   
}



