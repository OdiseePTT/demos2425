using NUnit.Framework.Legacy;

namespace Numbers.Tests
{
    public class NumbersOperationsTests
    {

        [Test]
        public void GetNumbersHigherOrEqualTo50_WithListOfNumbers_ReturnsNumberHigherOrEqualTo50()
        {

            // Arrange
            int[] numbers = { 1, 8, 3, 7, 50, 21, 55, 49, 51, 0 };
            NumbersOperations sut = new NumbersOperations(numbers);
            IEnumerable<int> expectedResult = new List<int>() { 50, 55, 51 };

            // Act
            IEnumerable<int> actualResult = sut.GetNumbersHigherOrEqualTo50();

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetNumbersBetween30And60Including_WithListOfNumbers_ReturnsCorrectList()
        {
            // Arrange
            int[] numbers = { 1, 29, 30, 31, 59, 60, 61, 2349786, 21498, 0, 45 };
            int[] expectedResult = { 30, 31, 59, 60, 45 };

            NumbersOperations sut = new NumbersOperations(numbers);


            // Act
            IEnumerable<int> actualResult = sut.GetNumbersBetween30And60Including();

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetDoubles_WithListOfIntegers_ReturnsDoublesOfIntegers()
        {

            // Arrange
            int[] numbers = { 0, -16, 20, 2024, -2012 };
            NumbersOperations sut = new NumbersOperations(numbers);
            int[] expectedResult =  { 0, -32, 40, 4048, -4024 };

            // Act
            IEnumerable<int> result = sut.GetDoubles();

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetLastNumberWithSquareSmallerThan2000_WithListContaining1PositiveNumberBelow45_ReturnsTheNumerBelow45()
        {

            // Arrange
            int[] numbers = { 50, 40, 200, 323, -50 };
            NumbersOperations sut = new NumbersOperations(numbers);
            int expectedResult = 40;

            // Act
            int actualResult = sut.GetLastNumberWithSquareSmallerThan2000();

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            ClassicAssert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void GetLastNumberWithSquareSmallerThan2000_WithListContainingNumberAbove45_ReturnsTheNumerBelow45()
        {

            // Arrange
            int[] numbers = { 50, 400, 200, 323, -50 };
            NumbersOperations sut = new NumbersOperations(numbers);
            int expectedResult = 0;

            // Act
            int actualResult = sut.GetLastNumberWithSquareSmallerThan2000();

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            ClassicAssert.AreEqual(expectedResult, actualResult);
        }
    }
}