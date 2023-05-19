namespace Benchmark.Services.Helpers
{
    public static class StringHelpers
    {
        public static int TryConvertStringToInt32(this string number)
        {
            try
            {
                return Convert.ToInt32(number);

            }
            catch (Exception ex)
            {
                //A non-integer has been entered as input, Handle error and return 0
                // TODO:What should behavior be for non-integer input
                //Additionail Error handling i.e Elmah, Logger Etc
                return 0;
            }
        }

    }
}
