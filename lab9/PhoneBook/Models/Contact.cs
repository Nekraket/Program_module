using System.Text.RegularExpressions;
using PhoneBook.ViewModels.Base;

namespace PhoneBook.Models
{
    /// <summary>
    /// Model — хранит бизнес-данные и бизнес-логику (валидацию), ничего не знает о View и ViewModel.
    /// </summary>
    public class Contact : ObservableObject
    {
        private string _name = string.Empty;
        private string _phone = string.Empty;

        public Contact(string name, string phone)
        {
            _name = name?.Trim() ?? string.Empty;
            _phone = phone?.Trim() ?? string.Empty;
            Validate();
        }

        public string Name
        {
            get => _name;
            set
            {
                if (Set(ref _name, value?.Trim() ?? string.Empty))
                {
                    Validate();
                }
            }
        }

        public string Phone
        {
            get => _phone;
            set
            {
                if (Set(ref _phone, value?.Trim() ?? string.Empty))
                {
                    Validate();
                }
            }
        }

        public bool IsValid { get; private set; }

        public string? ValidationError { get; private set; }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(_name))
                throw new ArgumentException("Имя контакта не может быть пустым");

            if (!IsValidPhone(_phone))
                throw new ArgumentException("Неверный формат телефона. Допустимо: +7XXXXXXXXXX, 8XXXXXXXXXX, XXXXXXXXXX");
        }

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            var pattern = @"^(\+7|8)?9\d{9}$";
            return Regex.IsMatch(phone, pattern);
        }
    }
}