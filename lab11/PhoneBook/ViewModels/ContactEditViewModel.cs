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

        private Contact _contact = null!;
        private string _editName = string.Empty;
        private string _editPhone = string.Empty;

        public ContactEditViewModel(INavigationService navigationService, IDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            SaveCommand = new RelayCommand(SaveContact, CanSaveContact);
            CancelCommand = new RelayCommand(Cancel);
        }

        public string EditName
        {
            get => _editName;
            set
            {
                if (Set(ref _editName, value))
                {
                    if (_contact != null)
                        _contact.Name = value;
                }
            }
        }

        public string EditPhone
        {
            get => _editPhone;
            set
            {
                if (Set(ref _editPhone, value))
                {
                    if (_contact != null)
                        _contact.Phone = value;
                }
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        /// <summary>
        /// Вызывается сервисом навигации после создания ViewModel.
        /// Получает выбранный контакт и инициализирует поля редактирования.
        /// </summary>
        public void OnNavigatedTo(object? parameter)
        {
            if (parameter is Contact contact)
            {
                _contact = contact;
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
                var validatedContact = new Contact(EditName, EditPhone);

                _contact.Name = validatedContact.Name;
                _contact.Phone = validatedContact.Phone;

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