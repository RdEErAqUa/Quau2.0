using Quau2._0.Infrastructure.Async;
using Quau2._0.Infrastructure.Commands.Base.NotifyChangedBaseCommand;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.Services.WorkDataFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.Infrastructure.Commands.AsyncLambdaCommands
{
    class ReadDataFromFileCommand : NotifyChangedCommand
    {
        private ObservableCollection<OneDimClusterModel> _OneDimClusterModels;
        public ObservableCollection<OneDimClusterModel> OneDimClusterModels { get => _OneDimClusterModels; set => Set(ref _OneDimClusterModels, value); }
        //
        private ObservableCollection<TwoDimensionalModel> _TwoDimensionalModels;

        private ObservableCollection<TwoDimensionalModel> TwoDimensionalModels { get => _TwoDimensionalModels; set => Set(ref _TwoDimensionalModels, value); }
        //
        private readonly String ClusterName;

        private readonly IOneDimensionalConvertService _OneDimensionalConverterService;
        private readonly ITwoDimensionalConvertService _TwoDimensionalConvertService;

        public ReadDataFromFileCommand(ObservableCollection<OneDimClusterModel> oneDimClusterModels, ObservableCollection<TwoDimensionalModel> twoDimensionalModels, 
            IOneDimensionalConvertService OneDimensionalConverterService, ITwoDimensionalConvertService TwoDimensionalConvertService, String ClusterName = "general")
        {
            this.OneDimClusterModels = oneDimClusterModels;
            this._TwoDimensionalModels = twoDimensionalModels;
            this.ClusterName = ClusterName;
            this._OneDimensionalConverterService = OneDimensionalConverterService;
            this._TwoDimensionalConvertService = TwoDimensionalConvertService;

            this.CommandRun = new AsyncLambdaCommand(OnExecuted, CanExecute);
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
                    switch (Int32.Parse((string)p))
                    {
                        //Случай, считывание данных как двомерные данные и одномерные данные
                        case 0:
                            break;
                        //Случай, считывание данных как одномерные данные
                        case 1:
                            //Считывание данных в одномерную выборку
                            var DataFromFile = _OneDimensionalConverterService.
                                FromFileToOneDimensionalData();

                            if (DataFromFile == null)
                                return;
                            //Проверка на существование кластера с данным названием. 
                            var clusterCount = OneDimClusterModels.Where(X => X.ClusterName == ClusterName).Count();
                            var countValue = clusterCount != 0 ? OneDimClusterModels.Where(X => X.ClusterName == ClusterName).First().OneDimensionalModels.Count : 0;
                            //
                            var OneDimData = new OneDimensionalModel {
                                OneDimensionalSampleModels =
                                new ObservableCollection<Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel>(DataFromFile.
                                Select(X => new Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel { X = X, Y = 0 })), FileName = $"{ClusterName}/OneDimSample/" +
                                $"{countValue}"
                                ,
                                OneDimensionalSampleModelsSorted = new ObservableCollection<Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel>(DataFromFile.
                                Select(X => new Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel { X = X, Y = 0 }).OrderBy(X => X.X))
                            };
                            //Добавление выборки в кластер
                            if(clusterCount != 0)
                                AsyncAddInObservableCollection.Add(OneDimClusterModels.Where(X => X.ClusterName == ClusterName).First().OneDimensionalModels,
                                    OneDimData);
                            else
                                AsyncAddInObservableCollection.Add(OneDimClusterModels,
                                    new OneDimClusterModel { ClusterName = ClusterName, OneDimensionalModels = new ObservableCollection<OneDimensionalModel> { OneDimData } });
                            break;
                        //Случай, считывание данных как двомерные данные
                        case 2:
                            _TwoDimensionalConvertService.FromFileToTwoDimensionalData();
                            break;
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
