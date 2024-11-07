using NSubstitute;
using NSubstitute.ReceivedExtensions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P = PhoneBook;

namespace PhoneBook.Nsub.Tests
{
    // 3 => Quickdials
    // 4.2 => AddContacts Ongeldig telefoonnummer
    // 5.1 => UpdateContact, Correcte data
    // 5.3 => UpdateContact, Reed bestaand telefoonnumemr
    // 6 => Favorite
    // 8.1 => AddQuickDial, beschikbare Sneltoets
    // 9 => Remove Quickdial
    internal class PhoneBookOperationsTests
    {
        [Test]
        public void Contacts_WithNoDataInPhoneBook_ReturnsEmptyList()
        {
            // Arrange
            IPhoneBook phoneBookDouble = Substitute.For<IPhoneBook>();
            phoneBookDouble.Contacts.Returns(new List<Contact>().ToImmutableList());
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
            IPhoneBook phoneBookDouble = Substitute.For<IPhoneBook>();
          
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);
            Contact contact1 = new Contact(1, "John", "Doe", "1234567");
            Contact contact2 = new Contact(2, "Jane", "Doe", "98765432");

            phoneBookDouble.Contacts.Returns(ImmutableList.Create(contact1, contact2));

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
            IPhoneBook phoneBookDouble = Substitute.For<IPhoneBook>();
            phoneBookDouble.Contacts.Returns(new List<Contact>()
            {
                new Contact(1, "John","Doe", "123456"),
                new Contact(2, "Jane","Doe", "123456"),
                new Contact(3, "Jaal","Doe", "123456"),
            }.ToImmutableList());

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
            IPhoneBook phoneBookDouble = Substitute.For<IPhoneBook>();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);
            Contact john = new Contact(1, "John", "Doe", "1234567");
            Contact jane = new Contact(2, "Jane", "Doe", "123456789");
            john.Favorite = true;

            phoneBookDouble.Contacts.Returns(ImmutableList.Create(john, jane));

            List<Contact> expectedResult = new List<Contact>() { john };

            // Act
            IEnumerable<Contact> result = sut.Favorites;

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedResult));
        }


        [Test]
        public void AddContact_WithCorrectInformation_AddsContactToPhonebook()
        {

            // Arrange
            IPhoneBook phoneBookDouble = Substitute.For<IPhoneBook>();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);
            phoneBookDouble.Contacts.Returns(ImmutableList.Create<Contact>());

            // Act
            sut.AddContact("John", "Doe", "1234567");

            // Assert
            phoneBookDouble.Received().AddContact(
                Arg.Is<Contact>(c => c.Id == 0 && c.FirstName == "John" && c.LastName == "Doe" && c.PhoneNumber == "1234567"));

            phoneBookDouble.Received().AddContact(new Contact(0, "John", "Doe", "1234567"));
        }


        [Test]
        public void RemoveContact_WithExistingContact_RemovesContactFromPhonebook()
        {

            // Arrange
            IPhoneBook phoneBookDouble = Substitute.For<IPhoneBook>();
            PhoneBookOperations sut = new PhoneBookOperations(phoneBookDouble);
            Contact contactToRemove = new Contact(1, "John", "Doe", "12345678");

            // Act
            sut.RemoveContact(contactToRemove);

            // Assert
            phoneBookDouble.Received().RemoveContact(contactToRemove);
        }


        // 3 => Quickdials
        [Test]
        public void QuickDials_WithContactsContainingQuickDials_ReturnsArrayWithQuickDials()
        {
            // Arrange :

            // Data maken
            Contact contact1 = new Contact(1, "John", "Doe", "123456789");
            contact1.QuickDial = 5;
            Contact contact2 = new Contact(2, "Jane", "Doe", "987654321");
            contact2.QuickDial = 1;
            Contact contact3 = new Contact(3, "Jaak", "Doe", "555555555");
            contact3.QuickDial = 2;
            Contact contact4 = new Contact(4, "Jos", "Doe", "444444444");

            // Testdouble maken
            IPhoneBook phoneBook = Substitute.For<IPhoneBook>(); // STUB object

            // Testdouble voorzien van data voor properties/methodes
            phoneBook.Contacts.Returns(ImmutableList.Create(contact1, contact2, contact3, contact4));

            // SUT maken met testdouble
            PhoneBookOperations sut = new PhoneBookOperations(phoneBook);

            Contact?[] expectedResult = { null, contact2, contact3, null, null, contact1, null, null, null, null };

            // Act
            ImmutableArray<Contact> result = sut.QuickDials;

            // Assert
            Assert.That(result.Count, Is.EqualTo(10)); // Niet noodzakelijk
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        // 4.2 => AddContacts Ongeldig telefoonnummer
        [Test]
        public void AddContacts_WithInvalidPhoneNumber_ThrowsException()
        {
            // Arrange
            IPhoneBook phoneBook = Substitute.For<IPhoneBook>(); // DUMMIE
            PhoneBookOperations sut = new PhoneBookOperations(phoneBook);

            // Act
            Action act = () => sut.AddContact("John", "Doe", "0");

            // Assert
            Assert.That(act, Throws.TypeOf<ArgumentException>().With.Message.EqualTo("Invalid phoneNumber (Parameter 'phoneNumber')"));
        }

        // 5.1 => UpdateContact, Correcte data
        
        // 5.3 => UpdateContact, Reeds bestaand telefoonnumemr
        
        // 6 => Favorite
        
        // 8.1 => AddQuickDial, beschikbare Sneltoets

        // 9 => Remove Quickdial
        [Test]
        public void RemoveQuickDial_ForContactWithQuickDial_RemovesQuickdial()
        {
            // Arrange
            IPhoneBook phoneBook = Substitute.For<IPhoneBook>(); // Spy
            PhoneBookOperations sut = new PhoneBookOperations(phoneBook);
            Contact contact = new Contact(1, "John", "Doe", "123456789");
            contact.QuickDial = 1;

            // Act
            sut.RemoveQuickDial(contact);


            // Assert
            //phoneBook.Received().UpdateContact(contact);
            //Assert.That(contact.QuickDial, Is.Null);
            phoneBook.Received().UpdateContact(Arg.Is<Contact>(
                c => c.QuickDial == null && c.Id == 1 && c.Favorite == false && c.FirstName == "John" && c.LastName == "Doe" && c.PhoneNumber == "123456789"
                ));
        }
    }
}
