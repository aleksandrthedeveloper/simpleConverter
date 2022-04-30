using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleConverter.Units.Celsius;
using System;

namespace SimpleConverter.Tests
{
    [TestClass]
    public class FahrenheitTests
    {
        [TestMethod]
        public void CreateFahrenheit_CorrectFormat()
        {
            //Arrange
            var fahrenheit451 = (451.0).Fahrenheit();

            //Act
            var farenfeitNumberAsText = fahrenheit451.ToString();

            //Assert
            Assert.AreEqual("451.00 °F", farenfeitNumberAsText);
        }

        [TestMethod]
        [DataRow(-500)]
        [DataRow(3E+33)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateIncorrectFahrenheit_ThrowException(double value)
        {
            //Act
            (value).Fahrenheit();
        }

        [TestMethod]
        [DataRow(-459.67)]
        [DataRow(0)]
        [DataRow(2.556E+33)]
        public void CreateEdgeCaseFahrenheit_NoException(double value)
        {
            //Act
            try
            {
                var farenfeitNumber = (value).Fahrenheit();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected exception: " + ex.Message);
            }
        }

        [TestMethod]
        public void ConvertFahrenheitToCelsius_Success()
        {
            //Arrange
            var fiveFahrenheit = (5.0).Fahrenheit();

            //Act
            Celsius fiveCelsiuisInCelsius = fiveFahrenheit.ToCelsius();

            //Assert (5°F − 32) × 5/9 = -15°C
            Assert.AreEqual(-15, fiveCelsiuisInCelsius.Value);
        }

        [TestMethod]
        public void ConvertFahrenheitToKelvin_Success()
        {
            //Arrange
            var fiveFahrenheit = (5.0).Fahrenheit();

            //Act
            Kelvin fiveCelsiuisInKelvin = fiveFahrenheit.ToKelvin();

            //Assert (5°F − 32) × 5/9 + 273.15 = 258.15K
            Assert.AreEqual(258.15, fiveCelsiuisInKelvin.Value);
        }
    }
}