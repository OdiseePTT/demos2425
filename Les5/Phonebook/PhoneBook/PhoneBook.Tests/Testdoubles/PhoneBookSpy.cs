using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Tests.Testdoubles
{
    internal class PhoneBookSpy : IPhoneBook
    {
        public ImmutableList<Contact> Contacts => new List<Contact>().ToImmutableList();

        public Contact LastAddedContact { get; set; }
        public Contact LastRemovedContact { get; set; }

        public void AddContact(Contact contact)
        {
            LastAddedContact = contact;
        }

        public void RemoveContact(Contact contact)
        {
            LastRemovedContact = contact;
        }

        public void UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
