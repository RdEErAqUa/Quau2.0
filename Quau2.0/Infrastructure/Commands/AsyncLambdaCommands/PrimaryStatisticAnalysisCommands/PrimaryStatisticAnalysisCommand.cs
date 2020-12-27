using Quau2._0.Infrastructure.Commands.Base.NotifyChangedBaseCommand;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.Infrastructure.Commands.AsyncLambdaCommands.PrimaryStatisticAnalysisCommands
{
    class PrimaryStatisticAnalysisCommand : NotifyChangedCommand
    {
        private readonly IPrimaryStatisticAnalysisService _primaryStatisticAnalysisService;
        private readonly ObservableCollection<OneDimClusterModel> _OneDimClusterModels;
        private readonly string clusterName;

        public PrimaryStatisticAnalysisCommand(IPrimaryStatisticAnalysisService primaryStatisticAnalysisService,
            ObservableCollection<OneDimClusterModel> OneDimClusterModels, String ClusterName)
        {

            this.CommandRun = new AsyncLambdaCommand(OnExecuted, CanExecute);
            this._primaryStatisticAnalysisService = primaryStatisticAnalysisService;
            this._OneDimClusterModels = OneDimClusterModels;
            this.clusterName = ClusterName;
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
                    //
                    try
                    {
                        var OneDimData = _OneDimClusterModels?.Where(X => X.ClusterName == clusterName)?.First()?.OneDimensionalModels?.Last();

                        _primaryStatisticAnalysisService.ClassSizeSet(OneDimData);
                    }
                    catch (System.InvalidOperationException)
                    {
                        return;
                    }
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
