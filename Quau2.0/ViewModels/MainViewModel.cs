using Quau2._0.Infrastructure.Commands;
using Quau2._0.Infrastructure.Commands.Base;
using Quau2._0.Models;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.Services.Interfaces;
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
        private ObservableCollection<OneDimensionalModel> _OneDimensionalModels;
        /// <summary>
        /// Коллекция одномерных выборок
        /// </summary>
        public ObservableCollection<OneDimensionalModel> OneDimensionalModels { get => _OneDimensionalModels; set => Set(ref _OneDimensionalModels, value); }
        #endregion


        #region TwoDimensionalModels : ObservableCollection<TwoDimensionalModel> - коллекция одномерных выборок
        private ObservableCollection<TwoDimensionalModel> _TwoDimensionalModels;
        /// <summary>
        /// Коллекция одномерных выборок
        /// </summary>
        public ObservableCollection<TwoDimensionalModel> TwoDimensionalModels { get => _TwoDimensionalModels; set => Set(ref _TwoDimensionalModels, value); }
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
        public MainViewModel(MenuViewModel _menuViewModel)
        {
            //Инициализация 
            this.OneDimensionalModels = new ObservableCollection<OneDimensionalModel> { };
            this.TwoDimensionalModels = new ObservableCollection<TwoDimensionalModel> { };

            //Инициализация пользовательских интерфейсов
            this.MenuModel = _menuViewModel;
            this.MenuModel.SetMainViewModel(this);
            this.MenuModel.OneDimensionalModels = this.OneDimensionalModels;
            this.MenuModel.TwoDimensionalModels = this.TwoDimensionalModels;
        }
    }
}
