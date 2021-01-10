using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.Infrastructure.Commands.Base
{
    internal interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object p);
    }
}