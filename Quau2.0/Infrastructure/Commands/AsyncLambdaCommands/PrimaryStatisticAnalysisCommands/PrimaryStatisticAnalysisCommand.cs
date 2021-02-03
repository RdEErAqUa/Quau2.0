using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Quau2._0.Infrastructure.Commands.Base.NotifyChangedBaseCommand;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;

namespace Quau2._0.Infrastructure.Commands.AsyncLambdaCommands.PrimaryStatisticAnalysisCommands
{
    internal class PrimaryStatisticAnalysisCommand : NotifyChangedCommand
    {
        private readonly ObservableCollection<OneDimClusterModel> _OneDimClusterModels;
        private readonly IPrimaryStatisticAnalysisService _primaryStatisticAnalysisService;
        private readonly string clusterName;

        private bool _isBusyCommand;
        private OneDimensionalModel _OneDimensionalModels;

        public PrimaryStatisticAnalysisCommand(IPrimaryStatisticAnalysisService primaryStatisticAnalysisService,
            OneDimensionalModel OneDimensionalModels)
        {
            CommandRun = new AsyncLambdaCommand(OnExecuted, CanExecute);
            _primaryStatisticAnalysisService = primaryStatisticAnalysisService;
            _OneDimensionalModels = OneDimensionalModels;
        }

        public PrimaryStatisticAnalysisCommand(IPrimaryStatisticAnalysisService primaryStatisticAnalysisService,
            ObservableCollection<OneDimClusterModel> OneDimClusterModels, string ClusterName)
        {
            CommandRun = new AsyncLambdaCommand(OnExecuted, CanExecute);
            _primaryStatisticAnalysisService = primaryStatisticAnalysisService;
            _OneDimClusterModels = OneDimClusterModels;
            clusterName = ClusterName;
        }

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
                    if (int.Parse((string) p) != 1 || !setOneDim()) return;
                    _primaryStatisticAnalysisService.PrimaryAnalysisRun(_OneDimensionalModels);
                    _OneDimensionalModels.SetAnalysis(_primaryStatisticAnalysisService);
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

        private bool setOneDim()
        {
            if (_OneDimClusterModels != null)
                try
                {
                    _OneDimensionalModels = _OneDimClusterModels?.Where(X => X.ClusterName == clusterName)?.First()
                        ?.OneDimensionalModels?.Last();
                }
                catch (InvalidOperationException)
                {
                    return false;
                }

            return true;
        }
    }
}