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

            this.ReadDataFromFile = new AsyncLambdaCommand(OnReadDataFromFileExecuted, CanReadDataFromFileExecute);
        }

        private bool _isBusyReadDataFromFile;

        public bool isBusyReadDataFromFile
        {
            get => _isBusyReadDataFromFile;
            private set => Set(ref _isBusyReadDataFromFile, value);
        }

        public ICommand ReadDataFromFile { get; }

        private async Task OnReadDataFromFileExecuted(object p)
        {
            try
            {
                isBusyReadDataFromFile = true;
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
                            //Проверка на существование кластера с данным названием. Если его нету - добавление нового кластера. 
                            if (OneDimClusterModels.Where(X => X.ClusterName == ClusterName).Count() == 0)
                                AsyncAddInObservableCollection.Add(OneDimClusterModels,
                                new OneDimClusterModel { ClusterName = ClusterName, OneDimensionalModels = new ObservableCollection<OneDimensionalModel> { } });

                            var OneDimData = new OneDimensionalModel {
                                OneDimensionalSampleModels =
                                new ObservableCollection<Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel>(DataFromFile.
                                Select(X => new Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel { X = X, Y = 0 })), FileName= $"{ClusterName}/OneDimSample/" +
                                $"{OneDimClusterModels.Where(X => X.ClusterName == ClusterName).First().OneDimensionalModels.Count}"
                            };
                            //

                            //Добавление выборки в кластер
                            AsyncAddInObservableCollection.Add(OneDimClusterModels.Where(X => X.ClusterName == ClusterName).First().OneDimensionalModels,
                                    OneDimData);
                            //
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
                isBusyReadDataFromFile = false;
            }
        }

        private bool CanReadDataFromFileExecute(object p)
        {
            return !isBusyReadDataFromFile;
        }
    }
}
