using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Quau2._0.Infrastructure.Commands;
using Quau2._0.Infrastructure.Commands.Base;
using Quau2._0.Services.Interfaces;

namespace Quau2._0.Services
{
    internal class MultipleBindingCommand : IMultipleBindingCommand
    {
        public ICommand AsyncMultipleCommand(params IAsyncCommand[] asyncCommands)
        {
            Func<object, Task> exectue = null;
            Func<object, bool> canexecute = null;

            foreach (var el in asyncCommands)
            {
                exectue += el.ExecuteAsync;
                canexecute += el.CanExecute;
            }

            return new AsyncLambdaCommand(exectue, canexecute);
        }

        public ICommand MultipleCommand(params ICommand[] asyncCommands)
        {
            throw new NotImplementedException();
        }
    }
}