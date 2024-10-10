using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrisdrankAutomaat.Tests
{
    internal class VendingmachineTests
    {

        // InsertCoins
        // precon + data : Coin nodig
        // Budget wordt verhoogd
        [Test]
        public void InsertCoins_ZonderBudgetMet2Euro_BudgetMoet2Zijn()
        {
            // Arrange
            VendingMachine sut = new VendingMachine();
            Coins twoEuroCoin = Coins.TWO_EURO;
            double expectedBudget = 2.00;

            // Act
            sut.InsertCoins(twoEuroCoin);

            // Assert
            ClassicAssert.AreEqual(expectedBudget, sut.Budget);
            Assert.That(sut.Budget, Is.EqualTo(expectedBudget));
        }

        [Test]
        public void InsertCoins_MetAlleCoins_BudgetMoet3Euro85CentZijn()
        {
            // Arrange
            VendingMachine sut = new VendingMachine();
            double expectedBudget = 3.85;

            // Act
            sut.InsertCoins(Coins.TWO_EURO);
            sut.InsertCoins(Coins.ONE_EURO);
            sut.InsertCoins(Coins.FIFTY_CENTS);
            sut.InsertCoins(Coins.TWENTY_CENTS);
            sut.InsertCoins(Coins.TEN_CENTS);
            sut.InsertCoins(Coins.FIVE_CENTS);

            // Assert
            ClassicAssert.AreEqual(expectedBudget, sut.Budget);
            Assert.That(sut.Budget, Is.EqualTo(expectedBudget));
        }

        // REFUND
        // 
        // Expected result =-> Budget==0 && refund returns correct bedrag

        [Test]
        public void Refund_MetBudgetAanwezig_BudgetWordt0EnReturnsCorrectBedrag()
        {
            // Arrange
            VendingMachine sut = new VendingMachine();
            sut.InsertCoins(Coins.ONE_EURO);
            sut.InsertCoins(Coins.FIFTY_CENTS);
            double expectedBudget = 0;
            double expectedReturnedAmount = 1.5;

            // Act
            double actualReturnedAmount = sut.Refund();
         
            // Assert
            Assert.Multiple(()=>{
                Assert.That(actualReturnedAmount, Is.EqualTo(expectedReturnedAmount));
                Assert.That(sut.Budget, Is.EqualTo(expectedBudget));
            });



          
        }
    }
}
