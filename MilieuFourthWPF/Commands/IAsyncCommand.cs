using System.Threading.Tasks;
using System.Windows.Input;

namespace MilieuFourthWPF
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
