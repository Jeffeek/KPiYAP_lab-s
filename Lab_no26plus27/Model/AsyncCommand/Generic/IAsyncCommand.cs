#region Using namespaces

using System.Threading.Tasks;
using System.Windows.Input;

#endregion

namespace Lab_no26plus27.Model.AsyncCommand.Generic
{
    public interface IAsyncCommand<in T> : ICommand
    {
        Task ExecuteAsync(T parameter);

        bool CanExecute(T parameter);
    }
}