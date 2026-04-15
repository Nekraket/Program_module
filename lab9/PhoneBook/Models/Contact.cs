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

        /// <summary>
        /// Конструктор модели Contact.
        /// </summary>
        public Contact(string name, string phone)
        {
            _name = name?.Trim() ?? string.Empty;
            _phone = phone?.Trim() ?? string.Empty;
            Validate();
        }

        /// <summary>
        /// Имя контакта. Не может быть пустым или состоять только из пробелов.
        /// При изменении свойства вызывается уведомление для UI.
        /// </summary>
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

        /// <summary>
        /// Номер телефона. Должен соответствовать форматам:
        /// - +7XXXXXXXXXX (11 цифр после +7)
        /// - 8XXXXXXXXXX (11 цифр, начинается с 8)
        /// - XXXXXXXXXX (10 цифр, без кода страны)
        /// </summary>
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

        /// <summary>
        /// Флаг, указывающий, является ли контакт валидным.
        /// Используется для проверки перед добавлением в коллекцию.
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Сообщение об ошибке валидации (если контакт невалиден).
        /// </summary>
        public string? ValidationError { get; private set; }

        /// <summary>
        /// Выполняет валидацию данных контакта.
        /// Устанавливает флаг IsValid и сообщение об ошибке.
        /// </summary>
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                IsValid = false;
                ValidationError = "Имя контакта не может быть пустым";
                OnPropertyChanged(nameof(IsValid));
                OnPropertyChanged(nameof(ValidationError));
                return;
            }

            if (!IsValidPhone(_phone))
            {
                IsValid = false;
                ValidationError = "Номер телефона имеет неверный формат. Допустимые форматы: +7XXXXXXXXXX, 8XXXXXXXXXX, XXXXXXXXXX";
                OnPropertyChanged(nameof(IsValid));
                OnPropertyChanged(nameof(ValidationError));
                return;
            }

            IsValid = true;
            ValidationError = null;
            OnPropertyChanged(nameof(IsValid));
            OnPropertyChanged(nameof(ValidationError));
        }

        /// <summary>
        /// Проверяет корректность номера телефона с помощью регулярного выражения.
        /// </summary>
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            // Регулярное выражение для проверки российских номеров телефона
            // Паттерн: ^(\+7|8)?\d{10}$ 
            // - ^ начало строки
            // - (\+7|8)? опционально: +7 или 8
            // - \d{10} ровно 10 цифр
            // - $ конец строки
            var pattern = @"^(\+7|8)?\d{10}$";
            return Regex.IsMatch(phone, pattern);
        }
    }
}