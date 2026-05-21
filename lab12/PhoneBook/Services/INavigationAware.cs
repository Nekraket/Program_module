namespace PhoneBook.Services
{
    /// <summary>
    /// Интерфейс для ViewModel, которые должны получать уведомление о навигации.
    /// Позволяет передавать параметры при переходе на экран.
    /// </summary>
    public interface INavigationAware
    {
        void OnNavigatedTo(object? parameter);
    }
}