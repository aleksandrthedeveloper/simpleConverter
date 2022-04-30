namespace SimpleConverter.Units.Celsius
{
    public class Celsius : BaseUnit
    {
        public Celsius(double value, bool isInBaseUnit = false) : base(value, isInBaseUnit)
        {
            MeasureName = "°C";
            MinValue = -273.15;
            MaxValue = 1.42E+33;
            Validate(Value); 
        }

        protected override double ConvertFromBaseUnit(double baseUnitValue) => baseUnitValue; 
        protected override double ConvertToBaseUnit(double value) => value;
    }

    public static class CelsiusExtensions
    {
        public static Celsius Celsius(this double value) => new Celsius(value);
        public static Celsius ToCelsius(this BaseUnit baseUnit) => new Celsius(baseUnit.BaseValue);
    }
}
