using NUnit.Framework.Legacy;
using System.Runtime.InteropServices;

namespace Vote.Tests
{
    public class PersonTests
    {


        /*
         * Preconditie: Persoon met leeftijd jonger dan 18 (bv. 15)
         * TestStap: Opvragen of die persoon mag stemmen
         * VerwachtResultaat: Persoon kan niet stemmen
         */

        [TestCase(15)]
        [TestCase(0)]
        [TestCase(17)]
        public void CanVote_EenPersoonJongerDan18Jaar_CanVoteIsFalse(int age)
        {

            // Arrange
            Person sut = new Person();
            sut.Age = age;

            // Act
            bool result = sut.CanVote;

            // Assert
            ClassicAssert.IsFalse(result);
            Assert.That(result, Is.False);
        }

        /*
         * Preconditie: Persoon met leeftijd ouder dan 18 (bv. 25)
         * TestStap: Opvragen of die persoon mag stemmen
         * VerwachtResultaat: Persoon kan  stemmen
         */

        [TestCase(18)]
        [TestCase(25)]
        [TestCase(100)]
        public void CanVote_LeeftijdOuderDan18Jaar_ReturnsTrue(int age)
        {

            // Arrange
            Person sut = new Person();
            sut.Age = age;

            // Act
            bool result = sut.CanVote;

            // Assert
            ClassicAssert.IsTrue(result);
            Assert.That(result, Is.True);
        }

    }
}