namespace SimpleConverter.Units
{
    /// <summary>
    /// Class responsible for common measure unit operations, like converting to and from base unit value,
    /// common validation and string representation formatting.
    /// </summary>
    public abstract class BaseUnit
    {
        protected readonly double _baseValue;

        public BaseUnit(double value, bool isInBaseUnit)
        {
            _baseValue = isInBaseUnit ? value : ConvertToBaseUnit(value);
        }

        // Properties that should be initiated in derived class constructor
        public double MaxValue { get; init; }
        public double MinValue { get; init; }
        public string MeasureUnit { get; init; }

        // Abstract method responsible for conversion from base to specific measure unit  
        protected abstract double ConvertFromBaseUnit(double baseUnitValue);

        // Abstract method responsible for conversion from specific to base measure unit
        protected abstract double ConvertToBaseUnit(double value);

        // Base measure unit value
        public double BaseValue => _baseValue;

        // Specific measure unit value
        public double Value => ConvertFromBaseUnit(_baseValue);

        // Formated specific measure unit value
        public new string ToString() => $"{Value.ToConverterFormat()} {MeasureUnit}";

        // Common validation method to avoid incorrect values
        protected void Validate(double value)
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentOutOfRangeException($"Value {value} should be in the range between {MaxValue} and {MinValue}.");
            }
        }
    }
}
