using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quau2._0.Infrastructure.Commands.Base.NotifyChangedBaseCommand;
using Quau2._0.Services.QuantileServices.Interfaces;
using Quau2._0.Services.WorkDataFile.JsonWriteServices.Interfaces;

namespace Quau2._0.Infrastructure.Commands.AsyncLambdaCommands.JsonCommands.JsonQuantileCommands
{
    class WriteInJsonCommand : NotifyChangedCommand
    {
        private IQuantileService _quantileService;

        public WriteInJsonCommand(IQuantileService quantileService)
        {
            CommandRun = new AsyncLambdaCommand(OnExecuted, CanExecute);
            _quantileService = quantileService;
        }

        private bool _isBusyCommand;

        public bool isBusyCommand
        {
            get => _isBusyCommand;
            private set => Set(ref _isBusyCommand, value);
        }

        public ICommand CommandRun { get; }

        private async Task OnExecuted(object p)
        {
            try
            {
                isBusyCommand = true;
                await Task.Run(() =>
                {
                    _quantileService.WriteValueQuantile();
                });
            }
            finally
            {
                isBusyCommand = false;
            }
        }

        private bool CanExecute(object p)
        {
            return !isBusyCommand;
        }
    }
}
