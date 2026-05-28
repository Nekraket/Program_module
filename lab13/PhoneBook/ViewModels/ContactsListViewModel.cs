using PhoneBook.Models;
using PhoneBook.Services;
using PhoneBook.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PhoneBook.ViewModels
{
    /// <summary>
    /// Главная ViewModel приложения — посредник между Model (Contact) и View (MainWindow).
    /// Содержит логику представления: коллекцию контактов, команды добавления/удаления.
    /// </summary>
    public class ContactsListViewModel : ObservableObject
    {
        private readonly PhoneBookDbНекрасова2307б2Context _context;

        private readonly IDialogService _dialogService;

        private readonly INavigationService _navigationService;

        public ObservableCollection<Contact> Contacts { get; set; }

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

        public ICommand EditCommand { get; }


        public ContactsListViewModel(PhoneBookDbНекрасова2307б2Context context, IDialogService dialogService, INavigationService navigationService)
        {
            _context = context;
            _dialogService = dialogService;
            _navigationService = navigationService;

            Contacts = new ObservableCollection<Contact>(_context.Contacts.ToList());

            AddCommand = new RelayCommand(AddContact, CanAddContact);
            DeleteCommand = new RelayCommand<Contact?>(DeleteContact, CanDeleteContact);
            EditCommand = new RelayCommand<Contact?>(EditContact, (c) => c != null);
        }

        private void AddContact()
        {
            if (Contacts.Any(c => c.Phone == Phone))
            {
                _dialogService.ShowWarning("Контакт с таким номером телефона уже существует!");
                return;
            }

            if (!IsValidPhone(Phone))
            {
                _dialogService.ShowError("Неверный формат телефона. Допустимо: +7 (XXX) XXX-XX-XX");
                return;
            }

            var newContact = new Contact
            {
                Name = Name,
                Phone = Phone
            };

            _context.Contacts.Add(newContact);
            _context.SaveChanges();
            Contacts.Add(newContact);

            Name = string.Empty;
            Phone = string.Empty;

            _dialogService.ShowInfo("Контакт успешно добавлен!");
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;
            var pattern = @"^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$";
            return System.Text.RegularExpressions.Regex.IsMatch(phone, pattern);
        }

        private bool CanAddContact()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Phone);
        }

        private void DeleteContact(Contact? contact)
        {
            if (contact == null)
            {
                return;
            }

            if (_dialogService.ShowConfirmation($"Удалить контакт \"{contact.Name}\"?"))
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                Contacts.Remove(contact);
            }
        }

        private bool CanDeleteContact(Contact? contact)
        {
            return contact != null;
        }

        private void EditContact(Contact? contact)
        {
            if (contact != null)
            {
                _navigationService.NavigateTo<ContactEditViewModel>(contact);
            }
        }
    }
}