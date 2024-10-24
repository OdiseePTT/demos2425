using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests.Testdoubles
{
    internal class PhoneBookStub2 : IPhoneBook
    {
        public ImmutableList<Contact> Contacts => new List<Contact>()
        {
            new Contact(1, "John", "Doe", "12345678"),
            new Contact(2, "Jane", "Doe", "12345678"),
        }.ToImmutableList();

        public void AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void RemoveContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
