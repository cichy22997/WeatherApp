using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeatherApp.Core
{
    public class CommandHandler : ICommand
    {
        private Action _action;
        private Action<object> _actionWithParameter;
        private bool _canExecute;

        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public CommandHandler(Action<object> action, bool canExecute)
        {
            _actionWithParameter = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter != null)
                _actionWithParameter(parameter);
            else
                _action();
        }
    }
}
