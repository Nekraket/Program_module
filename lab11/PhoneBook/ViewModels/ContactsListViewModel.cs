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
        private readonly IDialogService _dialogService;

        private readonly INavigationService _navigationService;

        private readonly IContactService _contactService;

        public ObservableCollection<Contact> Contacts => _contactService.Contacts;

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

        /// <summary>
        /// Конструктор с внедрением зависимости IDialogService (Constructor Injection).
        /// DI-контейнер автоматически передаст реализацию сервиса.
        /// </summary>
        public ContactsListViewModel(IDialogService dialogService, INavigationService navigationService, IContactService contactService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _contactService = contactService;

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

            try
            {
                var newContact = new Contact(Name, Phone);
                _contactService.AddContact(newContact);

                Name = string.Empty;
                Phone = string.Empty;

                _dialogService.ShowInfo("Контакт успешно добавлен!");
            }
            catch (ArgumentException ex)
            {
                _dialogService.ShowError(ex.Message, "Ошибка валидации");
            }
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
                _contactService.RemoveContact(contact);
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