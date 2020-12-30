using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Quau2._0.Infrastructure.Commands;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.SeriesModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.Services.SeriesServices.OneDimServices.Interfaces;
using Quau2._0.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.ViewModels.DataViewModels
{
    class DisplayDataViewModel : ViewModel
    {
        /// <summary>
        /// Поле для хранения главного окна
        /// </summary>
        private MainViewModel _MainViewModel;

        /// <summary>
        /// Сервис для построение графиков первичного статистического анализа
        /// </summary>
        private readonly IPrimaryAnalysisSeriesService primaryAnalysisSeriesService;

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - коллекция одномерных выборок
        private ObservableCollection<OneDimClusterModel> _OneDimClusterModels;
        /// <summary>
        /// Коллекция кластеров одномерных выборок
        /// </summary>
        public ObservableCollection<OneDimClusterModel> OneDimClusterModels { get => _OneDimClusterModels; set => Set(ref _OneDimClusterModels, value); }
        #endregion

        #region TwoDimensionalModels : ObservableCollection<TwoDimensionalModel> - коллекция одномерных выборок
        private ObservableCollection<TwoDimensionalModel> _TwoDimensionalModels;
        /// <summary>
        /// Коллекция одномерных выборок
        /// </summary>
        public ObservableCollection<TwoDimensionalModel> TwoDimensionalModels { get => _TwoDimensionalModels; set => Set(ref _TwoDimensionalModels, value); }
        #endregion

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - Класс выборок, который используются
        private ObservableCollection<OneDimensionalModel> _OneDimensionalModels;
        /// <summary>
        /// Класс выборок, который используются
        /// </summary>
        public ObservableCollection<OneDimensionalModel> OneDimensionalModels { get => _OneDimensionalModels; set => Set(ref _OneDimensionalModels, value); }
        #endregion

        #region OneDimensionalSeries : OneDimensionalPrimaryAnalysisSeriesModel - серия одномерных выборок

        private OneDimensionalPrimaryAnalysisSeriesModel _OneDimensionalSeries;

        /// <summary>
        /// Серия одномерных выборок, для функции плотности
        /// </summary>
        public OneDimensionalPrimaryAnalysisSeriesModel OneDimensionalSeries { get => _OneDimensionalSeries; set => Set(ref _OneDimensionalSeries, value); }

        #endregion

        public ICommand TestCommand
        {
            get => new LambdaCommand((p) =>
            {
                var values = new SeriesCollection { };
                var values2 = new SeriesCollection { };
                foreach (var el in OneDimensionalModels)
                {

                    values.Add(primaryAnalysisSeriesService.BuildStepLineSeries(el.PercentegData));
                    values2.Add(primaryAnalysisSeriesService.BuildStepLineSeries(el.HistogramData));
                }
                OneDimensionalSeries.OneDimensionalSeries = values;
                OneDimensionalSeries.OneDimensionalSeriesProbability = values2;
            });
        }

        /// <summary>
        /// Функция, для установки главного окна
        /// </summary>
        /// <param name="_MainViewModel">Ссылка на главное окно</param>
        public void SetMainViewModel(MainViewModel _MainViewModel)
        {
            this._MainViewModel = _MainViewModel;
        }

        /// <summary>
        /// Конструктор модели для конструктора VisualStudio
        /// </summary>
        /// IPrimaryAnalysisSeriesService
        public DisplayDataViewModel()
        {
            OneDimensionalSeries = new OneDimensionalPrimaryAnalysisSeriesModel();
        }
        /// <summary>
        /// Конструктор модели для DependencyInjection
        /// </summary>
        public DisplayDataViewModel(IPrimaryAnalysisSeriesService primaryAnalysisSeriesService)
        {
            OneDimensionalSeries = new OneDimensionalPrimaryAnalysisSeriesModel();
            this.primaryAnalysisSeriesService = primaryAnalysisSeriesService;
        }
    }
}
