using System.Collections.ObjectModel;
using PhoneBook.Models;

namespace PhoneBook.Services
{
    public interface IContactService
    {
        ObservableCollection<Contact> Contacts { get; }
        void AddContact(Contact contact);
        void RemoveContact(Contact contact);
        void UpdateContact(Contact oldContact, Contact newContact);
    }
}