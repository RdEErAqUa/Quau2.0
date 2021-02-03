using System.Windows.Input;
using Quau2._0.Infrastructure.Commands.Base;

namespace Quau2._0.Services.Interfaces
{
    internal interface IMultipleBindingCommand
    {
        ICommand AsyncMultipleCommand(params IAsyncCommand[] asyncCommands);

        ICommand MultipleCommand(params ICommand[] asyncCommands);
    }
}