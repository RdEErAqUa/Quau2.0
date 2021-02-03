using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using GongSolutions.Wpf.DragDrop;
using Quau2._0.Infrastructure.Commands;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.ViewModels.Base;
using Quau2._0.ViewModels.DataViewModels;
using Quau2._0.ViewModels.MenuViewModels;

namespace Quau2._0.ViewModels
{
    internal class MainViewModel : ViewModel, IDropTarget
    {
        /// <summary>
        ///     Конструктор модели для конструктора VisualStudio
        /// </summary>
        public MainViewModel()
        {
        }

        /// <summary>
        ///     Конструктор модели для DependencyInjection
        /// </summary>
        /// <param name="_menuViewModel">Ссылка на пользовательский интерфейс Menu окна</param>
        public MainViewModel(MenuViewModel _menuViewModel, DataViewModel _dataViewModel,
            DisplayDataViewModel _displayDataViewModel)
        {
            //Инициализация 
            OneDimClusterModels = new ObservableCollection<OneDimClusterModel>();
            //
            TwoDimensionalModels = new ObservableCollection<TwoDimensionalModel>();

            OneDimensionalModels = new ObservableCollection<OneDimensionalModel>();

            //Инициализация пользовательских интерфейсов
            MenuModel = _menuViewModel;
            MenuModel.SetMainViewModel(this);
            MenuModel.OneDimClusterModels = OneDimClusterModels;
            MenuModel.OneDimensionalModels = OneDimensionalModels;
            MenuModel.TwoDimensionalModels = TwoDimensionalModels;
            //
            DataModel = _dataViewModel;
            DataModel.SetMainViewModel(this);
            DataModel.OneDimClusterModels = OneDimClusterModels;
            DataModel.OneDimensionalModels = OneDimensionalModels;
            DataModel.TwoDimensionalModels = TwoDimensionalModels;
            //
            DisplayDataModel = _displayDataViewModel;
            DisplayDataModel.SetMainViewModel(this);
            DisplayDataModel.OneDimClusterModels = OneDimClusterModels;
            DisplayDataModel.OneDimensionalModels = OneDimensionalModels;
            DisplayDataModel.TwoDimensionalModels = TwoDimensionalModels;
        }

        /// <summary>
        ///     MenuModel - это ViewModel для представление Menu в пользовательском интерфейсе MenuUserControl
        /// </summary>
        public MenuViewModel MenuModel { get; }

        /// <summary>
        ///     DataModel - это ViewModel для представление View Data, в котором доступна вся информация о выбранных выборках
        /// </summary>
        public DataViewModel DataModel { get; }

        /// <summary>
        ///     DataModel - это ViewModel для представление View Data, в котором доступна вся информация о выбранных выборках
        /// </summary>
        public DisplayDataViewModel DisplayDataModel { get; }

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

        #region

        public ICommand TestCommand => new LambdaCommand(OnTestCommandExecute);

        private void OnTestCommandExecute(object p)
        {
        }

        #endregion

        #region DragOver and Drop - для перетаскивания элементов

        /// <summary>
        /// </summary>
        /// <param name="dropInfo"></param>
        public void DragOver(IDropInfo dropInfo)
        {
            dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
            dropInfo.Effects = DragDropEffects.Move;
        }

        public void Drop(IDropInfo dropInfo)
        {
            var Data = (OneDimensionalModel) dropInfo.Data;
            if (!OneDimensionalModels.Contains(Data))
                OneDimensionalModels.Add(Data);
        }

        #endregion
    }
}