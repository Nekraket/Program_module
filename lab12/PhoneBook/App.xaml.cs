using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Services;
using PhoneBook.ViewModels;
using PhoneBook.Views;
using PhoneBook.Models;
using System.Windows;

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

            var services = new ServiceCollection();

            services.AddDbContext<PhoneBookDbНекрасова2307б2Context>(options =>
            options.UseSqlServer(
            "Data Source=DESKTOP-3HCFBNF\\MSSQLSERVER01;Initial Catalog=PhoneBookDB_НЕКРАСОВА_2307Б2;Integrated Security=True;Trust Server Certificate=True"));

            services.AddSingleton<IDialogService, DialogService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<ContactsListViewModel>();
            services.AddTransient<ContactEditViewModel>();
            services.AddTransient<AboutViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainWindow>(sp =>
            {
                var window = new MainWindow();
                window.DataContext = sp.GetRequiredService<MainWindowViewModel>();
                return window;
            });

            var serviceProvider = services.BuildServiceProvider();

            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}