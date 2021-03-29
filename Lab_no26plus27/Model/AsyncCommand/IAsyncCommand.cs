#region Using namespaces

using System.Threading.Tasks;
using System.Windows.Input;

#endregion

namespace Lab_no26plus27.Model.AsyncCommand
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();

        bool CanExecute();
    }
}