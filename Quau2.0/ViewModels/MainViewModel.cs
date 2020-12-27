using Quau2._0.Infrastructure.Commands;
using Quau2._0.Infrastructure.Commands.Base;
using Quau2._0.Models;
using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.ViewModels.Base;
using Quau2._0.ViewModels.MenuViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.ViewModels
{
    class MainViewModel : ViewModel
    {
        /// <summary>
        /// MenuModel - это ViewModel для представление Menu в пользовательском интерфейсе MenuUserControl
        /// </summary>
        public MenuViewModel MenuModel { get; }

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

        #region

        public ICommand TestCommand { get => new LambdaCommand(OnTestCommandExecute); }

        private void OnTestCommandExecute(object p)
        {

        }

        #endregion

        /// <summary>
        /// Конструктор модели для конструктора VisualStudio
        /// </summary>
        public MainViewModel()
        {

        }
        /// <summary>
        /// Конструктор модели для DependencyInjection
        /// </summary>
        /// <param name="_menuViewModel">Ссылка на пользовательский интерфейс Menu окна</param>
        public MainViewModel(MenuViewModel _menuViewModel)
        {
            //Инициализация 
            this.OneDimClusterModels = new ObservableCollection<OneDimClusterModel> {  };
            //
            this.TwoDimensionalModels = new ObservableCollection<TwoDimensionalModel> { };

            //Инициализация пользовательских интерфейсов
            this.MenuModel = _menuViewModel;
            this.MenuModel.SetMainViewModel(this);
            this.MenuModel.OneDimClusterModels = this.OneDimClusterModels;
            this.MenuModel.TwoDimensionalModels = this.TwoDimensionalModels;
        }
    }
}
