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
        // Коллекция контактов с автоматическим обновлением UI
        public ObservableCollection<Contact> Contacts { get; }

        // Поле для имени нового контакта (привязка к TextBox)
        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        // Поле для телефона нового контакта (привязка к TextBox)
        private string _phone = string.Empty;
        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }

        // Выбранный контакт в DataGrid (привязка для удаления)
        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }

        // Команда добавления контакта (без параметра)
        public ICommand AddCommand { get; }

        // Команда удаления контакта (с параметром)
        public ICommand DeleteCommand { get; }

        /// <summary>
        /// Конструктор MainViewModel. Инициализирует коллекцию и команды.
        /// </summary>
        public MainViewModel()
        {
            // Инициализация коллекции (ObservableCollection автоматически обновляет UI)
            Contacts = new ObservableCollection<Contact>();

            // Инициализация команды добавления
            AddCommand = new RelayCommand(AddContact, () => CanAddContact());                    //?????

            // Инициализация команды удаления с параметром типа Contact
            DeleteCommand = new RelayCommand<Contact?>(DeleteContact, CanDeleteContact);
        }

        /// <summary>
        /// Добавляет новый контакт в коллекцию.
        /// Создаёт объект Contact из значений полей Name и Phone.
        /// При успешном добавлении очищает поля ввода.
        /// При ошибке валидации показывает сообщение пользователю.
        /// </summary>
        private void AddContact()
        {
            try
            {
                // Создание нового контакта (валидация происходит в конструкторе Contact)
                var newContact = new Contact(Name, Phone);

                // Добавление в коллекцию (UI обновится автоматически)
                Contacts.Add(newContact);

                Name = string.Empty;
                Phone = string.Empty;
            }
            catch (ArgumentException ex)
            {
                //этот славный мув конечно нарушает принцип разделения ответсвенности, но таков путь....
                MessageBox.Show(ex.Message, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Проверяет возможность добавления контакта.
        /// Команда AddCommand доступна, когда поля Name и Phone не пусты.
        /// </summary>
        private bool CanAddContact()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Phone);
        }

        /// <summary>
        /// Удаляет выбранный контакт из коллекции.
        /// </summary>
        private void DeleteContact(Contact? contact)
        {
            if (contact != null)
            {
                Contacts.Remove(contact);
            }
        }

        /// <summary>
        /// Проверяет возможность удаления контакта.
        /// Команда DeleteCommand доступна, когда выбран контакт в списке.
        /// </summary>
        private bool CanDeleteContact(Contact? contact)
        {
            return contact != null;
        }
    }
}