using Quau2._0.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.Services.Interfaces
{
    interface IMultipleBindingCommand
    {
        ICommand AsyncMultipleCommand(params IAsyncCommand[] asyncCommands);

        ICommand MultipleCommand(params ICommand[] asyncCommands);
    }
}
