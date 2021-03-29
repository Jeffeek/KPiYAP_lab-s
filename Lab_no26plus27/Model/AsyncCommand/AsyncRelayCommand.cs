#region Using namespaces

using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab_no26plus27.Model.Extensions;

#endregion

namespace Lab_no26plus27.Model.AsyncCommand
{
    public class AsyncRelayCommand : IAsyncCommand
    {
        private readonly Func<bool> _canExecute;
        private readonly IErrorHandler _errorHandler;
        private readonly Func<Task> _execute;

        private bool _isExecuting;

        public AsyncRelayCommand(Func<Task> execute,
                                 Func<bool> canExecute = null,
                                 IErrorHandler errorHandler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _errorHandler = errorHandler;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute() => !_isExecuting && (_canExecute?.Invoke() ?? true);

        public async Task ExecuteAsync()
        {
            if (CanExecute())
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                finally
                {
                    _isExecuting = false;
                }

            RaiseCanExecuteChanged();
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        #region Explicit implementations

        bool ICommand.CanExecute(object parameter) => CanExecute();

        void ICommand.Execute(object parameter) => ExecuteAsync().FireAndForgetSafeAsync(_errorHandler);

        #endregion
    }
}