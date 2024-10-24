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
    }
}
