namespace SimpleConverter.Units.Celsius
{
    /// <summary>
    /// Class reposnsible for Fahrenheit measure unit definition, including measure unit, min and max values
    /// and conversion logic implementation. Since base unit is Celsius, conversion methods implements
    /// Fahrenheit -> Celsius and Celsius -> Fahrenheit formulas.
    /// </summary>
    public class Fahrenheit : BaseUnit
    {
        public Fahrenheit(double value, bool isInBaseUnit = false) : base(value, isInBaseUnit)
        {
            MeasureUnit = "°F";
            MinValue = -459.67;
            MaxValue = 2.556E+33;
            Validate(Value);
        }

        // Celsius -> Fahrenheit conversion
        protected override double ConvertFromBaseUnit(double baseUnitValue) => (baseUnitValue * 1.8) + 32;

        // Fahrenheit -> Celsius conversion
        protected override double ConvertToBaseUnit(double value) => (value - 32) / 1.8;
    }

    /// <summary>
    /// Fluent API extension methods for better readability and extensibility
    /// </summary>
    public static class FahrenheitExtensions
    {
        public static Fahrenheit Fahrenheit(this double value) => new Fahrenheit(value);
        public static Fahrenheit ToFahrenheit(this BaseUnit baseUnit) => new Fahrenheit(baseUnit.BaseValue, isInBaseUnit: true);
    }
}
