namespace SimpleConverter
{
    /// <summary>
    /// Extension responsible for converting a measure unit value to the formatted string 
    /// </summary>
    public static class FormatExtensions
    {
        public static string ToConverterFormat(this double value)
        {
            // Since a value can be large (up to absolute hot temperature)
            // it is reasonable for better readability apply format with a group separator
            return value.ToString("N2");
        }
    }
}
