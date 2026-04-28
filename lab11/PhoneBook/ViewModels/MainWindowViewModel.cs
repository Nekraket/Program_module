using System.Windows.Input;
using PhoneBook.Services;
using PhoneBook.ViewModels.Base;

namespace PhoneBook.ViewModels
{
    /// <summary>
    /// ViewModel для главного окна (Shell).
    /// Управляет навигацией через меню.
    /// </summary>
    public class MainWindowViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public MainWindowViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowContactsCommand = new RelayCommand(ShowContacts);
            ShowAboutCommand = new RelayCommand(ShowAbout);

            _navigationService.NavigateTo<ContactsListViewModel>();
        }

        public INavigationService NavigationService => _navigationService;

        public ICommand ShowContactsCommand { get; }
        public ICommand ShowAboutCommand { get; }

        private void ShowContacts()
        {
            _navigationService.NavigateTo<ContactsListViewModel>();
        }

        private void ShowAbout()
        {
            _navigationService.NavigateTo<AboutViewModel>();
        }
    }
}