namespace SimpleConverter.Units.Celsius
{
    /// <summary>
    /// Class reposnsible for Celsius measure unit definition, including measure unit, min and max values
    /// and conversion logic implementation. Since base unit is Celsius, there is one to one conversion here. 
    /// </summary>
    public class Celsius : BaseUnit
    {
        public Celsius(double value, bool isInBaseUnit = false) : base(value, isInBaseUnit)
        {
            MeasureUnit = "°C";
            MinValue = -273.15;
            MaxValue = 1.42E+33;
            Validate(Value); 
        }

        protected override double ConvertFromBaseUnit(double baseUnitValue) => baseUnitValue; 
        protected override double ConvertToBaseUnit(double value) => value;
    }

    /// <summary>
    /// Fluent API extension methods for better readability and extensibility
    /// </summary>
    public static class CelsiusExtensions
    {
        public static Celsius Celsius(this double value) => new Celsius(value);
        public static Celsius ToCelsius(this BaseUnit baseUnit) => new Celsius(baseUnit.BaseValue);
    }
}
