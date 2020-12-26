using Quau2._0.Infrastructure.Commands.Base.NotifyChangedBaseCommand;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.Infrastructure.Commands.AsyncLambdaCommands.PrimaryStatisticAnalysisCommands
{
    class PrimaryStatisticAnalysisCommand : NotifyChangedCommand
    {
        private readonly IPrimaryStatisticAnalysisService _primaryStatisticAnalysisService;

        public PrimaryStatisticAnalysisCommand(IPrimaryStatisticAnalysisService primaryStatisticAnalysisService)
        {

            this.CommandRun = new AsyncLambdaCommand(OnExecuted, CanExecute);
            this._primaryStatisticAnalysisService = primaryStatisticAnalysisService;
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
