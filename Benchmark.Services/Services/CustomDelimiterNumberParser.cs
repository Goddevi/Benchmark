using Benchmark.Services;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public class CustomDelimiterNumberParser : DefaultNumberParser
{
    public const string delimiterSignifier = "//";

    private readonly bool _allowNegatives;
    private readonly bool _allowOverOneThousand;

    public CustomDelimiterNumberParser(bool allowNegatives = true, bool allowOverOneThousand = true)
    {
        _allowNegatives = allowNegatives;
        _allowOverOneThousand = allowOverOneThousand;
    }

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

            var parsedNumbers = numbersWithoutDelimiter.Split(new string[] { delimiter, "\n" }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(x => int.TryParse(x, NumberStyles.Integer, null, out int result) ? result : 0)
                                          .ToArray();
            if(!_allowNegatives)
            {
                HandleNegativeNumbers(parsedNumbers);
            }
            if(!_allowOverOneThousand)
            {
               parsedNumbers= HandleNumbersGreaterThan1000(parsedNumbers);
            }
           
            return parsedNumbers;
        }

        return base.ParseNumbers(input);
    }




}
