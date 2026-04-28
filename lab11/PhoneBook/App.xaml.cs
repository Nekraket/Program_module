using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Services;
using PhoneBook.ViewModels;
using PhoneBook.Views;

namespace PhoneBook
{
    /// <summary>
    /// Точка входа в приложение.
    /// Настройка IoC-контейнера и запуск приложения через Shell.
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 1. Создаём коллекцию сервисов
            var services = new ServiceCollection();

            // 2. Регистрируем сервисы с указанием Lifetime

            // ContactService — Singleton (хранит данные контактов)
            services.AddSingleton<IContactService, ContactService>();

            // DialogService — Singleton (не хранит состояние)
            services.AddSingleton<IDialogService, DialogService>();

            // NavigationService — Singleton (хранит состояние CurrentViewModel)
            services.AddSingleton<INavigationService, NavigationService>();

            // 3. Регистрируем ViewModel — Transient (новый экземпляр при каждом переходе)
            services.AddTransient<ContactsListViewModel>();
            services.AddTransient<ContactEditViewModel>();
            services.AddTransient<AboutViewModel>();

            // 4. Регистрируем MainWindowViewModel — Singleton (живёт всё время работы приложения)
            services.AddSingleton<MainWindowViewModel>();

            // 5. Регистрируем главное окно (Shell) с явной передачей DataContext через лямбду
            services.AddSingleton<MainWindow>(sp =>
            {
                var window = new MainWindow();
                window.DataContext = sp.GetRequiredService<MainWindowViewModel>();
                return window;
            });

            // 6. Создаём контейнер (ServiceProvider)
            var serviceProvider = services.BuildServiceProvider();

            // 7. Получаем главное окно из контейнера и запускаем приложение
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}