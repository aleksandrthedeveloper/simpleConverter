namespace SimpleConverter.Units.Celsius
{
    public class Kelvin : BaseUnit
    {
        public Kelvin(double value, bool isInBaseUnit = false) : base(value, isInBaseUnit)
        {
            MeasureName = "K";
            MinValue = 0;
            MaxValue = 1.42E+33;
            Validate(Value);
        }

        protected override double ConvertFromBaseUnit(double baseUnit) => baseUnit + 273.15;
        protected override double ConvertToBaseUnit(double value) => value - 273.15;
    }

    public static class KelvinExtensions
    {
        public static Kelvin Kelvin(this double value) => new Kelvin(value);
        public static Kelvin ToKelvin(this BaseUnit baseUnit) => new Kelvin(baseUnit.BaseValue, isInBaseUnit: true);
    }
}
