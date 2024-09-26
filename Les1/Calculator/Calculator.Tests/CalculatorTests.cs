using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Tests
{
    internal class CalculatorTests
    {

        [Test]
        public void Add_Met2PositiveGeheleGetallen_ReturnsCorrectPositiveSum()
        {
            // Arrange
            int number1 = 10;
            int number2 = 20;
            int expectedResult = 30;
            Calculator sut = new Calculator();

            // Act
            int actualResult = sut.Add(number1, number2);

            // Assert
            ClassicAssert.AreEqual(expectedResult, actualResult);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}
