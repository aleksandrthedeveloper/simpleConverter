namespace SimpleConverter.Units
{
    public abstract class BaseUnit
    {
        protected readonly double _baseValue;

        public BaseUnit(double value, bool isInBaseUnit)
        {
            _baseValue = isInBaseUnit ? value : ConvertToBaseUnit(value);
        }

        public double MaxValue { get; init; }
        public double MinValue { get; init; }
        public string MeasureName { get; init; }

        protected abstract double ConvertFromBaseUnit(double baseUnitValue);
        protected abstract double ConvertToBaseUnit(double value);

        public double BaseValue => _baseValue;
        public double Value => ConvertFromBaseUnit(_baseValue);
        public new string ToString() => $"{Value.ToConverterFormat()} {MeasureName}";

        protected void Validate(double value)
        {
            if (value < MinValue || value > MaxValue)
            {
                throw new ArgumentOutOfRangeException($"Value {value} should be in the range between {MaxValue} and {MinValue}.");
            }
        }
    }
}
