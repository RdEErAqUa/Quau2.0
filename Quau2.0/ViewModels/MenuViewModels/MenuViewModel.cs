using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Конструктор модели для DependencyInjection
        /// </summary>
        public MenuViewModel()
        {
        }
        /// <summary>
        /// Конструктор модели для конструктора VisualStudio
        /// </summary>
        public MenuViewModel(IOneDimensionalConvertService OneDimensionalConverterService, ITwoDimensionalConvertService TwoDimensionalConvertService)
        {
            this._OneDimensionalConverterService = OneDimensionalConverterService;
            this._TwoDimensionalConvertService = TwoDimensionalConvertService;
        }
    }
}
