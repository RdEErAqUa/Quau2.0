using Quau2._0.Infrastructure.Commands;
using Quau2._0.Infrastructure.Commands.Base;
using Quau2._0.Models;
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
            this.MenuModel = _menuViewModel;
        }
    }
}
