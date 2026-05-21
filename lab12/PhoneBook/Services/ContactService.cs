using System.Collections.ObjectModel;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public class ContactService : IContactService
    {
        public ObservableCollection<Contact> Contacts { get; } = new();

        public void AddContact(Contact contact)
        {
            Contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            Contacts.Remove(contact);
        }

        public void UpdateContact(Contact oldContact, Contact newContact)
        {
            var index = Contacts.IndexOf(oldContact);
            if (index >= 0)
            {
                Contacts[index] = newContact;
            }
        }
    }
}