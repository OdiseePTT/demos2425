using NSubstitute;

namespace HigherLowerGame.Tests
{
    public class HigherLowerAppTests
    {
 
        [Test]
        public void GuessNumber_WithNumberToLow_ReturnsResultHigher()
        {

            // Arrange
            IRandom random = Substitute.For<IRandom>();
            random.Next(default).ReturnsForAnyArgs(5);
            random.Next(Arg.Any<int>()).Returns(5);
            HigherLowerApp sut = new HigherLowerApp(random,10);

            // Act
            Result result = sut.GuessNumber(0);


            // Assert
            Assert.That(result, Is.EqualTo(Result.Higher));
        }
    }
}