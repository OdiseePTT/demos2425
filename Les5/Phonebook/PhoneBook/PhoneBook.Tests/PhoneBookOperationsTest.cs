using NUnit.Framework.Legacy;
using PhoneBook.Tests.Testdoubles;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests
{
    internal class PhoneBookOperationsTest
    {

        [Test]
        public void Contacts_WithNoDataInPhoneBook_ReturnsEmptyList()
        {
            // Arrange
            IPhoneBook phoneBookDouble =  new PhoneBookStub();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);

            // Act
            ImmutableList<Contact> result = sut.Contacts;

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Contact_With2ContactsInPhoneBook_ReturnsListWith2Items()
        {
            // Arrange
            IPhoneBook phoneBookDouble = new PhoneBookFake();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);
            Contact contact1 = new Contact(1, "John", "Doe", "1234567");
            Contact contact2 = new Contact(2, "Jane", "Doe", "98765432");

            phoneBookDouble.AddContact(contact1);
            phoneBookDouble.AddContact(contact2);

            // Act
            ImmutableList<Contact> result = sut.Contacts;

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result, Is.EquivalentTo(new List<Contact> { contact1, contact2 }));
        }

        [Test]
        public void Favorites_WithListOfContactWithNoFavorites_ReturnsEmptyList()
        {

            // Arrange
            IPhoneBook phoneBookDouble = new PhoneBookStub2();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);

            // Act
            IEnumerable<Contact> result = sut.Favorites;

            // Assert
            Assert.That(result, Is.Empty);
        }


        [Test]
        public void Favorites_WithListOfContactsWith1Favorite_ReturnsListContainingTheFavorite()
        {

            // Arrange
            IPhoneBook phoneBookDouble = new PhoneBookFake();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);
            
            Contact john  = new Contact(1,"John", "Doe", "12345678");
            john.Favorite = true;
            Contact jane = new Contact(2, "Jane", "Doe", "123456");
            phoneBookDouble.AddContact(john);
            phoneBookDouble.AddContact(jane);

            List<Contact> expectedResult = new List<Contact>() { john };
 
            // Act
            IEnumerable<Contact> result = sut.Favorites;

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }
        [Test]
        public void Favorites_WithListOfContactsWith1Favorite_ReturnsListContainingTheFavorite2()
        {

            // Arrange
            IPhoneBook phoneBookDouble = new PhoneBookStub3();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);

            List<Contact> expectedResult = new List<Contact>() {
                new Contact(1, "John","Doe", "12345678")
                {
                    Favorite = true
                }
            };

            Contact expectedContact = phoneBookDouble.Contacts[0];
 
            // Act
            Contact[] result = sut.Favorites.ToArray();

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedResult).UsingPropertiesComparer());
            Assert.That(result, Contains.Item(expectedContact).UsingPropertiesComparer());
        }

        [Test]
        public void AddContact_WithCorrectInformation_AddsContactToPhonebook()
        {

            // Arrange
            PhoneBookSpy phoneBookDouble = new PhoneBookSpy();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);

            // Act
            sut.AddContact("John", "Doe", "1234567");

            // Assert
            Assert.That(phoneBookDouble.LastAddedContact, Is.EqualTo(new Contact(0,"John", "Doe", "1234567")).UsingPropertiesComparer());

        }

        [Test]
        public void RemoveContact_WithExistingContact_RemovesContactFromPhonebook()
        {

            // Arrange
            PhoneBookSpy phoneBookDouble = new PhoneBookSpy();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);
            Contact contactToRemove = new Contact(1, "John", "Doe", "12345678");

            // Act
            sut.RemoveContact(contactToRemove);

            // Assert
            Assert.That(phoneBookDouble.LastRemovedContact, Is.EqualTo(contactToRemove));
        }

    }
}
