using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleConverter.Units.Celsius;
using System;

namespace SimpleConverter.Tests
{
    [TestClass]
    public class KelvinTests
    {
        [TestMethod]
        public void CreateKelvin_CorrectFormat()
        {
            //Arrange
            var kelvinNumber = (20.04366).Kelvin();

            //Act
            var kelvinNumberAsText = kelvinNumber.ToString();

            //Assert
            Assert.AreEqual("20.04 K", kelvinNumberAsText);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(1.43E+33)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateIncorrectKelvin_ThrowException(double value)
        {
            //Act
            (value).Kelvin();
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1.42E+33)]
        public void CreateEdgeCaseKelvin_NoException(double value)
        {
            //Act
            try
            {
                var kelvinNumber = (value).Kelvin();
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected exception: " + ex.Message);
            }
        }

        [TestMethod]
        public void ConvertKelvinToCelsius_Success()
        {
            //Arrange
            var fiveKelvin = (5.0).Kelvin();

            //Act
            Celsius fiveKelvinInCelsius = fiveKelvin.ToCelsius();

            //Assert 5K − 273.15 = -268.15 °C
            Assert.AreEqual(-268.15, fiveKelvinInCelsius.Value);
        }

        [TestMethod]
        public void ConvertKelvinToFahrenheit_Success()
        {
            //Arrange
            var fiveKelvin = (5.0).Kelvin();

            //Act
            Fahrenheit fiveCelsiuisInFahrenheit = fiveKelvin.ToFahrenheit();

            //Assert (5K − 273.15) × 9/5 + 32 = -450.67°F
            Assert.AreEqual(-450.67, fiveCelsiuisInFahrenheit.Value, 0.001);
        }
    }
}