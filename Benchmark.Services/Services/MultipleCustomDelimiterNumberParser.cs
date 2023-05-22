using Benchmark.Services;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

public class MultipleCustomDelimiterNumberParser : DefaultNumberParser
{
    public const string delimiterSignifier = "//";

    private readonly bool _allowNegatives;
    private readonly bool _allowLargeNumbers;

    public MultipleCustomDelimiterNumberParser(bool allowNegatives = true, bool allowLargeNumbers = true)
    {
        _allowNegatives = allowNegatives;
        _allowLargeNumbers = allowLargeNumbers;
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

            //split string into array of chars as there is no signifier
            char[] delimiters = HandlePotentialMultipleDelimiters(delimiter);

            var parsedNumbers = numbersWithoutDelimiter.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(x => int.TryParse(x, NumberStyles.Integer, null, out int result) ? result : 0)
                                          .ToArray();
            if(!_allowNegatives)
            {
                HandleNegativeNumbers(parsedNumbers);
            }
            if(!_allowLargeNumbers)
            {
               parsedNumbers= HandleLargeNumbers(parsedNumbers);
            }
           
            return parsedNumbers;
        }

        return base.ParseNumbers(input);
    }




}
