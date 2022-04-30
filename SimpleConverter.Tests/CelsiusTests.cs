using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleConverter.Units.Celsius;
using System;

namespace SimpleConverter.Tests
{
    [TestClass]
    public class CelsiusTests
    {
        [TestMethod]
        public void CreateCelsius_CorrectFormat()
        {
            //Arrange
            var celsiusNumber = (20.04366).Celsius();

            //Act
            var celsiusNumberAsText = celsiusNumber.ToString();

            //Assert
            Assert.AreEqual("20.04 °C", celsiusNumberAsText);
        }

        [TestMethod]
        [DataRow(-500)]
        [DataRow(3E+33)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateIncorrectCelsius_ThrowException(double value)
        {
            //Act
            (value).Celsius();
        }

        [TestMethod]
        [DataRow(-273.15)]
        [DataRow(0)]
        [DataRow(1.42E+33)]
        public void CreateEdgeCaseCelsius_NoException(double value)
        {
            //Act
            try
            {
                var celsiusNumber = (value).Celsius();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected exception: " + ex.Message);
            }
        }

        [TestMethod]
        public void ConvertCelsiusToFahrenheit_Success()
        {
            //Arrange
            var fiveCelsius = (5.0).Celsius();

            //Act
            Fahrenheit fiveCelsiuisInToFahrenheit = fiveCelsius.ToFahrenheit();

            //Assert (5°C × 9/5) + 32 = 41°F
            Assert.AreEqual(41, fiveCelsiuisInToFahrenheit.Value);
        }

        [TestMethod]
        public void ConvertCelsiusToKelvin_Success()
        {
            //Arrange
            var fiveCelsius = (5.0).Celsius();

            //Act
            Kelvin fiveCelsiuisInKelvin = fiveCelsius.ToKelvin();

            //Assert 5°C + 273.15 = 278.15K
            Assert.AreEqual(278.15, fiveCelsiuisInKelvin.Value);
        }
    }
}