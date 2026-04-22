using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PhoneBook.ViewModels.Base
{
    /// <summary>
    /// Базовый класс для всех ViewModel.
    /// Реализует интерфейс INotifyPropertyChanged для уведомления представления (View) о том, 
    /// что данные в модели представления (ViewModel) изменились.
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged для указанного свойства.
        /// </summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Устанавливает значение поля и вызывает событие PropertyChanged, если значение изменилось.
        /// Универсальный вспомогательный метод для сокращения кода в свойствах ViewModel.
        /// </summary>
        protected bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}