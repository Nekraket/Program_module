using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PhoneBook.Models;
using PhoneBook.ViewModels.Base;

namespace PhoneBook.ViewModels
{
    /// <summary>
    /// Главная ViewModel приложения — посредник между Model (Contact) и View (MainWindow).
    /// Содержит логику представления: коллекцию контактов, команды добавления/удаления.
    /// </summary>
    public class MainViewModel : ObservableObject
    {
        public ObservableCollection<Contact> Contacts { get; }

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private string _phone = string.Empty;
        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }

        public ICommand AddCommand { get; }

        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            Contacts = new ObservableCollection<Contact>();

            AddCommand = new RelayCommand(AddContact, () => CanAddContact());                    //?????

            DeleteCommand = new RelayCommand<Contact?>(DeleteContact, CanDeleteContact);
        }

        private void AddContact()
        {
            try
            {
                var newContact = new Contact(Name, Phone);

                Contacts.Add(newContact);

                Name = string.Empty;
                Phone = string.Empty;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool CanAddContact()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Phone);
        }

        private void DeleteContact(Contact? contact)
        {
            if (contact != null)
            {
                Contacts.Remove(contact);
            }
        }

        private bool CanDeleteContact(Contact? contact)
        {
            return contact != null;
        }
    }
}