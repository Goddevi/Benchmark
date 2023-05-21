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
            return input.Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => int.TryParse(x, NumberStyles.Integer, null, out int result) ? result : 0)
                        .ToArray();
        }
    }

}


