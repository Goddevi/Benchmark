using Benchmark.Services;
using System.Globalization;

public class CustomDelimiterNumberParser : DefaultNumberParser
{
    public const string delimiterSignifier = "//";

    private readonly bool _allowNegatives;
    private readonly bool _allowLargeNumbers;

    /// <summary>
    /// CustomDelimiterNumberParser by default allows negative 
    /// values and values over a set limit
    /// </summary>
    /// <param name="allowNegatives"></param>
    /// <param name="allowOverOneThousand"></param>
    public CustomDelimiterNumberParser(bool allowNegatives = true, bool allowLargeNumbers = true)
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

            //we can calculate the delimiter as being between the end of the signifier and the begining of the end index 
            string delimiter = input.Substring(delimiterSignifier.Length, delimiterEndIndex - 2);
            //retrieve the numbers from the string after the end index
            string numbersWithoutDelimiter = input.Substring(delimiterEndIndex + 1);

            //this code remains similar, can be moved to a seperate method
            var parsedNumbers = numbersWithoutDelimiter.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(x => int.TryParse(x, NumberStyles.Integer, null, out int result) ? result : 0)
                                          .ToArray();
            //configuration based actions
            if (!_allowNegatives)
            {
                HandleNegativeNumbers(parsedNumbers);
            }
            if (!_allowLargeNumbers)
            {
                parsedNumbers = HandleLargeNumbers(parsedNumbers);
            }

            return parsedNumbers;
        }

        //if no custom delimiter is given, defer to the base
        return base.ParseNumbers(input);
    }




}
