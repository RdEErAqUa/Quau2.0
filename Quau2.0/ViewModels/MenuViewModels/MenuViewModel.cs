using Quau2._0.Infrastructure.Commands;
using Quau2._0.Infrastructure.Commands.AsyncLambdaCommands;
using Quau2._0.Infrastructure.Commands.AsyncLambdaCommands.PrimaryStatisticAnalysisCommands;
using Quau2._0.Infrastructure.Commands.Base;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
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
using System.ComponentModel;
using Quau2._0.Services.Interfaces;

namespace Quau2._0.ViewModels.MenuViewModels
{
    class MenuViewModel : ViewModel
    {
        /// <summary>
        /// Сервис для считывание данных как одномерная выборка
        /// </summary>
        private readonly IOneDimensionalConvertService _OneDimensionalConverterService;

        /// <summary>
        /// Сервис для считывание данных как двомерная выборка
        /// </summary>
        private readonly ITwoDimensionalConvertService _TwoDimensionalConvertService;
        /// <summary>
        /// Сервис для первичного статистического анализа
        /// </summary>
        private readonly IPrimaryStatisticAnalysisService _PrimaryStatisticAnalysisService;
        private readonly IMultipleBindingCommand _MultipleBindingCommand;

        /// <summary>
        /// Сервис, для предпросмотра выборки
        /// </summary>
        private readonly PreviewViewModel _PreviewModel;

        #region OneDimClusterModels : ObservableCollection<OneDimensionalModel> - коллекция одномерных выборок
        private ObservableCollection<OneDimClusterModel> _OneDimClusterModels;
        /// <summary>
        /// Коллекция кластеров одномерных выборок
        /// </summary>
        public ObservableCollection<OneDimClusterModel> OneDimClusterModels { get => _OneDimClusterModels; set => Set(ref _OneDimClusterModels, value); }
        #endregion

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - Класс выборок, который используются
        private ObservableCollection<OneDimensionalModel> _OneDimensionalModels;
        /// <summary>
        /// Класс выборок, который используются
        /// </summary>
        public ObservableCollection<OneDimensionalModel> OneDimensionalModels { get => _OneDimensionalModels; set => Set(ref _OneDimensionalModels, value); }
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

        #region ClusterName : String - название кластера

        private String _ClusterName = "general";
        /// <summary>
        /// ClusterName - название кластера. При его смене, меняется и команда ReadDataFromFile и PrimaryAnalysis
        /// </summary>
        public String ClusterName
        {
            get => _ClusterName; set
            {
                if (Set(ref _ClusterName, value))
                {
                    OnPropertyChanged(nameof(ReadDataFromFile));
                    OnPropertyChanged(nameof(PrimaryAnalysis));
                    OnPropertyChanged(nameof(SomeCommand));
                }
            }
        }

        #endregion

        #region Commands

        #region ReadDataFromFile - считать данные из файла
        /// <summary>
        /// ReadDataFromFile - считывает данные как выборки из файла.
        /// </summary>
        public ICommand ReadDataFromFile { get => new ReadDataFromFileCommand(
            OneDimClusterModels, TwoDimensionalModels, _OneDimensionalConverterService, 
            _TwoDimensionalConvertService, ClusterName).CommandRun; }
        #endregion 

        #region PrimaryAnalysis - первичный статистический анализ для выборки
        /// <summary>
        /// PrimaryAnalysis - первичный статистический анализ для выборки. Также устанавливается для каждой выборки ссылка на сервис
        /// первичного статистического анализа. При обновлении ClassSize, запускается повторный первичный анализ. 
        /// </summary>
        public ICommand PrimaryAnalysis { get => new PrimaryStatisticAnalysisCommand(_PrimaryStatisticAnalysisService,
            OneDimClusterModels, ClusterName).CommandRun; }
        #endregion

        #endregion

        #region

        public ICommand SomeCommand { get => _MultipleBindingCommand.AsyncMultipleCommand(ReadDataFromFile as IAsyncCommand, PrimaryAnalysis as IAsyncCommand); }

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
        public MenuViewModel(IOneDimensionalConvertService OneDimensionalConverterService, ITwoDimensionalConvertService TwoDimensionalConvertService,
            IPrimaryStatisticAnalysisService primaryStatisticAnalysisService, IMultipleBindingCommand multipleBindingCommand ,PreviewViewModel PreviewModel)
        {
            this._OneDimensionalConverterService = OneDimensionalConverterService;
            this._TwoDimensionalConvertService = TwoDimensionalConvertService;
            this._PrimaryStatisticAnalysisService = primaryStatisticAnalysisService;
            this._MultipleBindingCommand = multipleBindingCommand;
            this._PreviewModel = PreviewModel;
        }
    }
}
