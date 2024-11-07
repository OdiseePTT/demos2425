using NSubstitute;
using NUnit.Framework;
using Yahtzee;

namespace Yathzee.Tests
{
    public class YathzeeGameTests
    {

        [Test]
        public void CalculateYahtzeeValue_ForOnesWithNoOnesRolled_Return0()
        {
            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(1, 7).Returns(6, 5, 4, 3, 2);
            YahtzeeGame sut = new YahtzeeGame(randomProvider);
            sut.RollAllDice();

            // Act
            int result = sut.CalculateYahtzeeValue(YahtzeeCategory.Ones);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateYahtzeeValue_ForOnesWithAllOnesRolled_Returns5()
        {

            // Arrange
            IRandomProvider randomProvider = Substitute.For<IRandomProvider>();
            randomProvider.Next(1, 7).Returns(1);
            YahtzeeGame sut = new YahtzeeGame(randomProvider);
            sut.RollAllDice();

            // Act
            int result = sut.CalculateYahtzeeValue(YahtzeeCategory.Ones);

            // Assert
            Assert.That(result, Is.EqualTo(5));

        }
    }
}