using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidator.Tests
{
    internal class AgeValidatorTests
    {
        [TestCase(18)]
        [TestCase(35)]
        [TestCase(40)]
        [TestCase(69)]
        [TestCase(70)]
        public void IsValidAge_MetCorrecteLeeftijd_ReturnsTrue(int leeftijd)
        {
            // Arrange
            AgeValidator sut = new AgeValidator();

            // Act
            bool result = sut.IsValidAge(leeftijd);

            // Assert
            Assert.That(result, Is.True);
            ClassicAssert.IsTrue(result);
        }


        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(17)]
        [TestCase(71)]
        [TestCase(100)]
        public void IsValidAge_MetInCorrecteLeeftijd_ReturnsFalse(int leeftijd)
        {

            // Arrange
            AgeValidator sut = new AgeValidator();

            // Act
            bool result = sut.IsValidAge(leeftijd);

            // Assert
            Assert.That(result, Is.False);
            ClassicAssert.IsFalse(result);

        }
    }
}
