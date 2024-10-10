using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Calculator.Tests
{
    internal class CalculatorTests
    {

        //naamgeving: MethodeDieWeTesten_SituatieWaarinWeTesten_VerwachteResultaat

        /** Te testen methode: Sum
         *  Precondities + Data : Number1 & Number2 => positieve getallen
         *  Resultaat : Correcte Som van Number1 en Number2
         */
        [Test]
        public void Sum_MetPositieveGetallen_CorrecteSom()
        {

            // Arrange
            Calculator sut = new Calculator();
            int number1 = 63;
            int number2 = 84;
            double expectedResult = 147;

            // Act
            double result = sut.Sum(number1, number2);

            // Assert
            ClassicAssert.AreEqual(expectedResult, result);
            // Of
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        public void Multiply_MetPositieveGetallen_CorrectProduct()
        {

            // Arrange
            Calculator sut = new Calculator();
            int number1 = 6;
            int number2 = 8;
            double expectedResult = 48;

            // Act
            double result = sut.Multiply(number1, number2);

            // Assert
            ClassicAssert.AreEqual(expectedResult, result);
            // Of
            Assert.That(result, Is.EqualTo(expectedResult));

        }


        /*
         * Te Testen methode: IsEven
         * Precondities + data : Met Even getallen
         * Resultaat: Geeft True
         */
        [TestCase(0)]
        [TestCase(8)]
        [TestCase(100)]
        [TestCase(-200)]
        public void IsEven_MetEvenGetal_ReturnsTrue(int number)
        {
            // Arrange
            Calculator sut = new Calculator();

            // Act
            bool result = sut.IsEven(number);

            // Assert
            ClassicAssert.IsTrue(result);

            Assert.That(result, Is.True);
        }


        // Te Testen methode: ConvertToBinary
        // Precon + Data: Positief getal
        // Resultaat: Correcte binaire String
        [TestCase(17, "10001")]
        [TestCase(15, "1111")]
        [TestCase(255, "11111111")]
        public void ConvertToBinary_MetPositieveInteger_ReturnsCorrectBinaryString(int getal, string expectedResult)
        {
            // Arrange
            Calculator sut = new Calculator();
            //int getal = 17;
            //string expectedResult = "10001";

            // Act
            string result = sut.ConvertToBinary(getal);

            // Assert
            ClassicAssert.AreEqual(expectedResult, result);
            // OF
            Assert.That(result, Is.EqualTo(expectedResult));

        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            // Arrange
            Calculator sut = new Calculator();
            int number1 = 10;
            int number2 = 0;

            // Act
            TestDelegate act = () => sut.Divide(number1, number2);
            Action act2 = () => sut.Divide(number1, number2);

            // Assert

            Assert.Throws<DivideByZeroException>(act);

            Assert.That(act2, Throws.TypeOf<DivideByZeroException>().And.Message.Contains("divide"));

        }
    }
}
