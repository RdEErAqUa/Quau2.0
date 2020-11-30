using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.Infrastructure.Commands.Base
{
    internal interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object p);
    }
}
