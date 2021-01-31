using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Wpf;
using OxyPlot;
using Quau2._0.Infrastructure.Commands;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.SeriesModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.Services.SeriesServices.OneDimServices.Interfaces;
using Quau2._0.ViewModels.Base;

namespace Quau2._0.ViewModels.DataViewModels
{
    internal class DisplayDataViewModel : ViewModel
    {
        /// <summary>
        ///     Сервис для построение графиков первичного статистического анализа
        /// </summary>
        private readonly IPrimaryAnalysisSeriesService primaryAnalysisSeriesService;

        /// <summary>
        ///     Поле для хранения главного окна
        /// </summary>
        private MainViewModel _MainViewModel;

        /// <summary>
        ///     Конструктор модели для конструктора VisualStudio
        /// </summary>
        /// IPrimaryAnalysisSeriesService
        public DisplayDataViewModel()
        {
            OneDimensionalSeries = new OneDimensionalPrimaryAnalysisSeriesModel();
        }

        /// <summary>
        ///     Конструктор модели для DependencyInjection
        /// </summary>
        public DisplayDataViewModel(IPrimaryAnalysisSeriesService primaryAnalysisSeriesService)
        {
            OneDimensionalSeries = new OneDimensionalPrimaryAnalysisSeriesModel();
            this.primaryAnalysisSeriesService = primaryAnalysisSeriesService;
        }

        public ICommand TestCommand =>
            new LambdaCommand(p =>
            {
                var values = new PlotModel();
                var values2 = new PlotModel();
                foreach (var el in OneDimensionalModels)
                {
                    values.Series.Add(primaryAnalysisSeriesService.BuildStepLineSeriesOxy(el.PercentegData));
                    if(el.Distribution != null && el.Distribution.DataDensity != null)
                        values.Series.Add(primaryAnalysisSeriesService.BuildLineOxy(el.Distribution.DataDensity, 5));
                    values2.Series.Add(
                        primaryAnalysisSeriesService.BuildStepLineSeriesOxy(el.HistogramData, 5, false));
                    if (el.Distribution != null && el.Distribution.DataProbability != null)
                        values2.Series.Add(primaryAnalysisSeriesService.BuildLineOxy(el.Distribution.DataProbability, 5));
                }

                OneDimensionalSeries.OneDimensionalSeries = values;
                OneDimensionalSeries.OneDimensionalSeriesProbability = values2;
            });


        /// <summary>
        ///     Функция, для установки главного окна
        /// </summary>
        /// <param name="_MainViewModel">Ссылка на главное окно</param>
        public void SetMainViewModel(MainViewModel _MainViewModel)
        {
            this._MainViewModel = _MainViewModel;
        }

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - коллекция одномерных выборок

        private ObservableCollection<OneDimClusterModel> _OneDimClusterModels;

        /// <summary>
        ///     Коллекция кластеров одномерных выборок
        /// </summary>
        public ObservableCollection<OneDimClusterModel> OneDimClusterModels
        {
            get => _OneDimClusterModels;
            set => Set(ref _OneDimClusterModels, value);
        }

        #endregion

        #region TwoDimensionalModels : ObservableCollection<TwoDimensionalModel> - коллекция одномерных выборок

        private ObservableCollection<TwoDimensionalModel> _TwoDimensionalModels;

        /// <summary>
        ///     Коллекция одномерных выборок
        /// </summary>
        public ObservableCollection<TwoDimensionalModel> TwoDimensionalModels
        {
            get => _TwoDimensionalModels;
            set => Set(ref _TwoDimensionalModels, value);
        }

        #endregion

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - Класс выборок, который используются

        private ObservableCollection<OneDimensionalModel> _OneDimensionalModels;

        /// <summary>
        ///     Класс выборок, который используются
        /// </summary>
        public ObservableCollection<OneDimensionalModel> OneDimensionalModels
        {
            get => _OneDimensionalModels;
            set => Set(ref _OneDimensionalModels, value);
        }

        #endregion

        #region OneDimensionalSeries : OneDimensionalPrimaryAnalysisSeriesModel - серия одномерных выборок

        private OneDimensionalPrimaryAnalysisSeriesModel _OneDimensionalSeries;

        /// <summary>
        ///     Серия одномерных выборок, для функции плотности
        /// </summary>
        public OneDimensionalPrimaryAnalysisSeriesModel OneDimensionalSeries
        {
            get => _OneDimensionalSeries;
            set => Set(ref _OneDimensionalSeries, value);
        }

        #endregion
    }
}