using System.ComponentModel;

namespace PhoneBook.Services
{
    /// <summary>
    /// Сервис навигации между экранами.
    /// </summary>
    public interface INavigationService : INotifyPropertyChanged
    {
        object? CurrentViewModel { get; }

        void NavigateTo<TViewModel>(object? parameter = null) where TViewModel : class;
    }
}