using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests.Testdoubles
{
    internal class PhoneBookFake : IPhoneBook
    {
        private List<Contact> _contacts = new List<Contact>();

        public ImmutableList<Contact> Contacts
        {
            get => _contacts.ToImmutableList();
        }

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
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
