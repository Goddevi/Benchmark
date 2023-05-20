using Benchmark.Services;

using Benchmark.Services.Interfaces;
using System.Globalization;

namespace Benchmark.Services
{
    public class CommaSplitter : ISplitter
    {
        public string[] Split(string numbers)
        {
            return numbers.Split(',');
        }
    }

}


