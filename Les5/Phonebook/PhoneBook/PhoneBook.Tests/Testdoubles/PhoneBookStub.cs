using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests.Testdoubles
{
    internal class PhoneBookStub : IPhoneBook
    {
        public ImmutableList<Contact> Contacts => new List<Contact>().ToImmutableList();

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
