namespace SimpleConverter.Units.Celsius
{
    /// <summary>
    /// Class reposnsible for Kelvin measure unit definition, including measure unit, min and max values
    /// and conversion logic implementation. Since base unit is Celsius, conversion methods implements
    /// Kelvin -> Celsius and Celsius -> Kelvin formulas.
    /// </summary>
    public class Kelvin : BaseUnit
    {
        public Kelvin(double value, bool isInBaseUnit = false) : base(value, isInBaseUnit)
        {
            MeasureUnit = "K";
            MinValue = 0;
            MaxValue = 1.42E+33;
            Validate(Value);
        }

        // Celsius -> Kelvin conversion
        protected override double ConvertFromBaseUnit(double baseUnit) => baseUnit + 273.15;

        // Kelvin -> Celsius conversion
        protected override double ConvertToBaseUnit(double value) => value - 273.15;
    }

    /// <summary>
    /// Fluent API extension methods for better readability and extensibility
    /// </summary>
    public static class KelvinExtensions
    {
        public static Kelvin Kelvin(this double value) => new Kelvin(value);
        public static Kelvin ToKelvin(this BaseUnit baseUnit) => new Kelvin(baseUnit.BaseValue, isInBaseUnit: true);
    }
}
