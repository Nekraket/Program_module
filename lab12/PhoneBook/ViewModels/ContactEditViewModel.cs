using System.Windows.Input;
using PhoneBook.Models;
using PhoneBook.Services;
using PhoneBook.ViewModels.Base;

namespace PhoneBook.ViewModels
{
    /// <summary>
    /// ViewModel для экрана редактирования контакта.
    /// Реализует INavigationAware для получения выбранного контакта из навигации.
    /// </summary>
    public class ContactEditViewModel : ObservableObject, INavigationAware
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;
        private readonly IContactService _contactService;

        private Contact _originalContact = null!;
        private string _editName = string.Empty;
        private string _editPhone = string.Empty;

        public ContactEditViewModel(
            INavigationService navigationService,
            IDialogService dialogService,
            IContactService contactService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _contactService = contactService;

            SaveCommand = new RelayCommand(SaveContact, CanSaveContact);
            CancelCommand = new RelayCommand(Cancel);
        }

        public string EditName
        {
            get => _editName;
            set => Set(ref _editName, value);
        }

        public string EditPhone
        {
            get => _editPhone;
            set => Set(ref _editPhone, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is Contact contact)
            {
                _originalContact = contact;
                EditName = contact.Name;
                EditPhone = contact.Phone;
            }
        }

        private bool CanSaveContact()
        {
            return !string.IsNullOrWhiteSpace(EditName) && !string.IsNullOrWhiteSpace(EditPhone);
        }

        private void SaveContact()
        {
            try
            {
                // Создаём новый контакт с отредактированными данными
                var updatedContact = new Contact(EditName, EditPhone);

                // Обновляем через сервис (заменяем старый контакт новым)
                _contactService.UpdateContact(_originalContact, updatedContact);

                _dialogService.ShowInfo("Контакт успешно сохранён!");
                _navigationService.NavigateTo<ContactsListViewModel>();
            }
            catch (ArgumentException ex)
            {
                _dialogService.ShowError(ex.Message, "Ошибка валидации");
            }
        }

        private void Cancel()
        {
            _navigationService.NavigateTo<ContactsListViewModel>();
        }
    }
}