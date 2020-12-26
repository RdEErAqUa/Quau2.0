using Quau2._0.Infrastructure.Commands;
using Quau2._0.Infrastructure.Commands.AsyncLambdaCommands;
using Quau2._0.Infrastructure.Commands.AsyncLambdaCommands.PrimaryStatisticAnalysisCommands;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.ViewModels.Base;
using Quau2._0.ViewModels.PreviewViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.ViewModels.MenuViewModels
{
    class MenuViewModel : ViewModel
    {
        /// <summary>
        /// Сервис для считывание данных как одномерная выборка
        /// </summary>
        private IOneDimensionalConvertService _OneDimensionalConverterService;

        /// <summary>
        /// Сервис для считывание данных как двомерная выборка
        /// </summary>
        private ITwoDimensionalConvertService _TwoDimensionalConvertService;

        /// <summary>
        /// Сервис, для предпросмотра выборки
        /// </summary>
        private readonly PreviewViewModel _PreviewModel;

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - коллекция одномерных выборок
        private ObservableCollection<OneDimClusterModel> _OneDimClusterModels;
        /// <summary>
        /// Коллекция кластеров одномерных выборок
        /// </summary>
        public ObservableCollection<OneDimClusterModel> OneDimClusterModels { get => _OneDimClusterModels; set => Set(ref _OneDimClusterModels, value); }
        #endregion

        #region TwoDimensionalModels : ObservableCollection<TwoDimensionalModel> - коллекция двомерных выборок
        private ObservableCollection<TwoDimensionalModel> _TwoDimensionalModels;
        /// <summary>
        /// Коллекция одномерных выборок
        /// </summary>
        public ObservableCollection<TwoDimensionalModel> TwoDimensionalModels { get => _TwoDimensionalModels; set => Set(ref _TwoDimensionalModels, value); }
        #endregion

        /// <summary>
        /// Поле для хранения главного окна
        /// </summary>
        private MainViewModel _MainViewModel;


        #region Commands

        #region ReadDataFromFile - считать данные из файла
        /// <summary>
        /// ReadDataFromFile - считывает данные как выборки из файла.
        /// </summary>
        public ICommand ReadDataFromFile { get => new ReadDataFromFileCommand(OneDimClusterModels, TwoDimensionalModels, _OneDimensionalConverterService, _TwoDimensionalConvertService).CommandRun; }
        #endregion

        #endregion

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
        public MenuViewModel()
        {
        }
        /// <summary>
        /// Конструктор модели для DependencyInjection
        /// </summary>
        /// <param name="OneDimensionalConverterService">Сервис, для считывание одномерных выборок</param>
        /// <param name="TwoDimensionalConvertService">Сервис, для считывание двомерных выборок</param>
        /// <param name="PreviewModel">Окно превью</param>
        public MenuViewModel(IOneDimensionalConvertService OneDimensionalConverterService, ITwoDimensionalConvertService TwoDimensionalConvertService, PreviewViewModel PreviewModel)
        {
            this._OneDimensionalConverterService = OneDimensionalConverterService;
            this._TwoDimensionalConvertService = TwoDimensionalConvertService;
            this._PreviewModel = PreviewModel;
        }
    }
}
