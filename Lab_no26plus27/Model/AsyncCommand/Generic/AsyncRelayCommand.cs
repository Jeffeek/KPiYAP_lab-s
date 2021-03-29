#region Using namespaces

using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab_no26plus27.Model.Extensions;

#endregion

namespace Lab_no26plus27.Model.AsyncCommand.Generic
{
    public class AsyncRelayCommand<T> : IAsyncCommand<T>
    {
        private readonly Func<T, bool> _canExecute;
        private readonly IErrorHandler _errorHandler;
        private readonly Func<T, Task> _execute;

        private bool _isExecuting;

        public AsyncRelayCommand(Func<T, Task> execute,
                                 Func<T, bool> canExecute = null,
                                 IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(T parameter) => !_isExecuting && (_canExecute?.Invoke(parameter) ?? true);

        public async Task ExecuteAsync(T parameter)
        {
            if (CanExecute(parameter))
                try
                {
                    _isExecuting = true;
                    await _execute(parameter);
                }
                finally
                {
                    _isExecuting = false;
                }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #region Explicit implementations

        bool ICommand.CanExecute(object parameter) => CanExecute((T)parameter);

        void ICommand.Execute(object parameter) => ExecuteAsync((T)parameter).FireAndForgetSafeAsync(_errorHandler);

        #endregion
    }
}