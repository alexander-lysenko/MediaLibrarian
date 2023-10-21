using System;
using System.Windows.Input;

namespace MediaLibrarian.Models
{
    // https://ru.stackoverflow.com/a/1487377
    public class Command<T> : ICommand
    {
        private readonly Action<T> _execute;
        private readonly Predicate<object> _canExecute;

        public Command(Action<T> execute, Predicate<object> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object parameter) => _execute((T)parameter);

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}