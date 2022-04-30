# Temperature converter

### Task:

Implement temperature converter.
It should support converting from/to any existing temperature. For a demo, three Temperature Scales is enough: Fahrenheit, Celsius and Kelvin. It should also support any future temperature later.
Unit test.No need any UI.

Task clarification questions and answers:

- What measure unit precision should be implemented?
  - Two numbers after the dot.
- Should the converter have a validation\values range?
  - Temperature values should be correct, from absolute zero to absolute hot (https://www.sciencealert.com/the-hottest-and-coldest-temperatures-according-to-physics).
- Should the converter have overload methods for different number types (int, float, double, decimal)?
  - Only one type that fits best for measurement is enough.

### Implementation details:
Since a converter must be able to convert any type to any type, there are two ways to implement this requirement:
1. Implement all type to type conversion methods (for example, Kelvin would have ToCelsius() and ToFarenheit() methods). If we would like to add an additional temperature it would require alter all existing temperature types and would impact all solution.
2. Implement two phase conversion, when each temperature type could to convert to some base temperature unit (for example, Celsius) and then it can be converted to any type. This approach requires less convsersion methods, each type should implement only conversion to and from base unit.


I've picked the second approach because of simpler conversions, that a positive effect on extensibility and maintainability.


### Usage:

```C#
// Construct            
var fiveCelsius = (5.0).Celsius(); 
          
// Convert
Kelvin fiveCelsiuisInKelvin = fiveCelsius.ToKelvin();

// Object usage
Console.Log(fiveCelsiuisInKelvin.Value) //278.15
Console.Log(fiveCelsiuisInKelvin.ToString()) //278.15 K
```


### Converter extension:
In case you want to extend the converter and add an additional temperature unit you need to create a new class with some required information
- Measure unit name
- Absolute cold temperature, expressed in new temperature type measure unit
- Absolute hot temperature, expressed in new temperature type measure unit
- New temperature -> Celsius conversion formula
- Celsius -> New temperature type conversion formula
```C#
public class Romer : BaseUnit
{
    public Romer(double value, bool isInBaseUnit = false) : base(value, isInBaseUnit)
    {
        MeasureUnit = "Rø";

        // Absolute cold temperature 
        MinValue = -135.9;

        // Absolute hot temperature
        MaxValue = 1.42E+33;

        Validate(Value);
    }

    // Celsius -> Romer conversion formula
    protected override double ConvertFromBaseUnit(double baseUnit) => (baseUnit * 0.525) + 7.5;

    // Romer -> Celsius conversion formula
    protected override double ConvertToBaseUnit(double value) => (value - 7.5) / 0.525;
}
```
