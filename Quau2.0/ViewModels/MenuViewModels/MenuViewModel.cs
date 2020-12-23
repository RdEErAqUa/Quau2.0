using Quau2._0.Infrastructure.Commands;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.ViewModels.Base;
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

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - коллекция одномерных выборок
        private ObservableCollection<OneDimensionalModel> _OneDimensionalModels;
        /// <summary>
        /// Коллекция одномерных выборок
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


        #region Commands

        #region ReadDataFromFile - считать данные из файла

        private bool _isBusyReadDataFromFile;
        public bool isBusyReadDataFromFile
        {
            get => _isBusyReadDataFromFile;
            private set => Set(ref _isBusyReadDataFromFile, value);
        }

        public ICommand ReadDataFromFile { get; private set; }
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
                            OneDimensionalModels.Add(new OneDimensionalModel { OneDimensionalSampleModels = 
                                new ObservableCollection<Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel>(_OneDimensionalConverterService.
                                FromFileToOneDimensionalData().
                                Select(X => new Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel { X = X, Y = 0})) });
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
        #endregion

        #endregion

        /// <summary>
        /// Функция, для установки главного окна
        /// </summary>
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
        public MenuViewModel(IOneDimensionalConvertService OneDimensionalConverterService, ITwoDimensionalConvertService TwoDimensionalConvertService)
        {
            this._OneDimensionalConverterService = OneDimensionalConverterService;
            this._TwoDimensionalConvertService = TwoDimensionalConvertService;

            //
            CommandInitialization();
            //
        }

        /// <summary>
        /// Функция, для инициализация команд
        /// </summary>
        private void CommandInitialization()
        {
            this.ReadDataFromFile = new AsyncLambdaCommand(OnReadDataFromFileExecuted, CanReadDataFromFileExecute);
        }
    }
}
