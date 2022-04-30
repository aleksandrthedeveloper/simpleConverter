namespace SimpleConverter.Units.Celsius
{
    public class Fahrenheit : BaseUnit
    {
        public Fahrenheit(double value, bool isInBaseUnit = false) : base(value, isInBaseUnit)
        {
            MeasureName = "°F";
            MinValue = -459.67;
            MaxValue = 2.556E+33;
            Validate(Value);
        }

        protected override double ConvertFromBaseUnit(double baseUnitValue) => (baseUnitValue * 1.8) + 32;
        protected override double ConvertToBaseUnit(double value) => (value - 32) / 1.8;
    }

    public static class FahrenheitExtensions
    {
        public static Fahrenheit Fahrenheit(this double value) => new Fahrenheit(value);
        public static Fahrenheit ToFahrenheit(this BaseUnit baseUnit) => new Fahrenheit(baseUnit.BaseValue, isInBaseUnit: true);
    }
}
