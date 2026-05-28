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
        private readonly PhoneBookDbНекрасова2307б2Context _context;

        private Contact _originalContact = null!;
        private string _editName = string.Empty;
        private string _editPhone = string.Empty;

        public ContactEditViewModel(
            INavigationService navigationService,
            IDialogService dialogService,
            PhoneBookDbНекрасова2307б2Context context)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _context = context;

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
            if (!IsValidPhone(EditPhone))
            {
                _dialogService.ShowError("Неверный формат телефона. Допустимо: +7 (XXX) XXX-XX-XX");
                return;
            }

            _originalContact.Name = EditName;
            _originalContact.Phone = EditPhone;

            _context.Contacts.Update(_originalContact);
            _context.SaveChanges();

            _dialogService.ShowInfo("Контакт успешно сохранён!");
            _navigationService.NavigateTo<ContactsListViewModel>();
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }
            var pattern = @"^\+7 \(\d{3}\) \d{3}-\d{2}-\d{2}$";
            return System.Text.RegularExpressions.Regex.IsMatch(phone, pattern);
        }

        private void Cancel()
        {
            _navigationService.NavigateTo<ContactsListViewModel>();
        }
    }
}