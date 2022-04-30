namespace SimpleConverter
{
    public static class FormatExtensions
    {
        public static string ToConverterFormat(this double value)
        {
            return value.ToString("N2");
        }
    }
}
