using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Tests
{
    internal class CustomerTests
    {
/*        Context: we maken een programma voor het beheer van de inventaris van een webshop
    Test case: Aankoop lukt indien voldoende voorraad

    Beschrijving: indien de klant producten koopt die voldoende voorradig zijn, wordt de aankoop succesvol afgerond en wordt de inventaris bijgewerkt.
    
    Pre-condities: er zijn 10 flessen shampoo beschikbaar in de inventaris

    Stappen: de klant koopt 5 flessen shampoo
    
     Resultaten (post-condities):
    De aankoop is gelukt
    Het aantal flessen shampoo van de inventaris werd met 5 verlaagd*/

        [Test]
        public void Purchase_MetGenoegInventaris_AankoopLuktEnInventarisIsVerlaagd()
        {
            Debug.WriteLine(" Purchase_MetGenoegInventaris_AankoopLuktEnInventarisIsVerlaagd");
            // Arrange
            Store store = CreateStoreWithInventory(Product.Shampoo, 10);
            Customer sut = new Customer();

            // Act
            bool result = sut.Purchase(store, Product.Shampoo, 5);

            // Assert
            ClassicAssert.IsTrue(result);
            Assert.That(result, Is.True);

            ClassicAssert.AreEqual(5, store.GetInventory(Product.Shampoo));
            Assert.That(store.GetInventory(Product.Shampoo), Is.EqualTo(5));

        }



        [Test]
        public void Purchase_MetTeWeinigInventaris_AankoopFaaltEnInventarisBlijftGelijk()
        {
            Debug.WriteLine("Purchase_MetTeWeinigInventaris_AankoopFaaltEnInventarisBlijftGelijk");
            // Arrange
            Store store = CreateStoreWithInventory(Product.Shampoo, 5);
            Customer sut = new Customer();

            // Act
            bool result = sut.Purchase(store, Product.Shampoo, 15);

            // Assert
            ClassicAssert.IsFalse(result);
            Assert.That(result, Is.False);

            ClassicAssert.AreEqual(5, store.GetInventory(Product.Shampoo));
            Assert.That(store.GetInventory(Product.Shampoo), Is.EqualTo(5));

        }

        private Store CreateStoreWithInventory(Product product,int quantity)
        {
            Store store = new Store();
            store.AddInventory(product, quantity);
            return store;
        }
        [SetUp]
        public void Setup()
        {
            Debug.WriteLine("Setup");
        }

        [TearDown]
        public void TearDown()
        {
            Debug.WriteLine("TearDown");
        }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Debug.WriteLine("OneTimeSetup");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.WriteLine("OneTimeTearDown");
        }
    }
}
