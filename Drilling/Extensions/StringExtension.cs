namespace Drilling.Extensions
{
    public static class StringExtension
    {
        public static double ConvertToDouble(this string value) => double.Parse(value.Replace(".", ","));
    }
}
