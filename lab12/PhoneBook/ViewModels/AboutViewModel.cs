using PhoneBook.ViewModels.Base;

namespace PhoneBook.ViewModels
{
    /// <summary>
    /// ViewModel для экрана "О программе".
    /// </summary>
    public class AboutViewModel : ObservableObject
    {
        public string AppName => "Телефонная книга";
        public string Version => "Версия 2.0 (с навигацией)";
        public string Author => "Некрасова Е.В.";
        public string Description => "Приложение для управления списком контактов с навигацией между экранами";
    }
}