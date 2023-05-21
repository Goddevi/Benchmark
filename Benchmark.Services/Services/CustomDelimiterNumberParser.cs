using Benchmark.Services;
using System.Globalization;

public class CustomDelimiterNumberParser : DefaultNumberParser
{
    public const string delimiterSignifier = "//";
    public override int[] ParseNumbers(string input)
    {
        if (input == null)
            return new int[0];

        //Custom Delimiter requires the input starting with the delimiterSignifier defined above
        if (input.StartsWith(delimiterSignifier))
        {
            int delimiterEndIndex = input.IndexOf('\n');

       
            string delimiter = input.Substring(delimiterSignifier.Length, delimiterEndIndex - 2);
            string numbersWithoutDelimiter = input.Substring(delimiterEndIndex + 1);

            return numbersWithoutDelimiter.Split(new string[] { delimiter, "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(x => int.TryParse(x, NumberStyles.Integer, null, out int result) ? result : 0)
                                          .ToArray();
        }

        return base.ParseNumbers(input);
    }
}
