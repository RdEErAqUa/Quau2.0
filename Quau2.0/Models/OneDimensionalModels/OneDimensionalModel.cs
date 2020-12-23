using Quau2._0.Models.Base;
using Quau2._0.Models.OneDimensionalModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Models.OneDimensionalModels
{
    class OneDimensionalModel : Model
    {
        #region FileName : String - название файла, в котором хранилась выборка
        private String _FileName;
        /// <summary>
        /// Название файла, в котором хранилась выборка
        /// </summary>
        public String FileName { get => _FileName; set => Set(ref _FileName, value); }
        #endregion

        #region ClassSize : int - размер класса, на которую разбита выборка
        private int _ClassSize;
        /// <summary>
        /// Размер класса, на которую разбита выборка
        /// </summary>
        public int ClassSize { get => _ClassSize; set => Set(ref _ClassSize, value); }
        #endregion

        #region OneDimensionalSampleModels : ObservableCollection<OneDimensionalSampleModel> - коллекция, которая хранит представление нашей одномерной выборки
        private ObservableCollection<OneDimensionalSampleModel> _OneDimensionalSampleModels;
        /// <summary>
        /// Коллекция, которая хранит представление одномерной выборки
        /// </summary>
        public ObservableCollection<OneDimensionalSampleModel> OneDimensionalSampleModels { get => _OneDimensionalSampleModels; set => Set(ref _OneDimensionalSampleModels, value); }
        #endregion

        #region OneDimensionalSampleModelsSorted : ObservableCollection<OneDimensionalSampleModel> - коллекция, которая хранит представление нашей одномерной выборки в отсортированом порядке по возрастанию
        private ObservableCollection<OneDimensionalSampleModel> _OneDimensionalSampleModelsSorted;
        /// <summary>
        /// Коллекция, которая хранит представление одномерной выборки в отсортированом порядке по возрастанию
        /// </summary>
        public ObservableCollection<OneDimensionalSampleModel> OneDimensionalSampleModelsSorted { get => _OneDimensionalSampleModelsSorted; set => Set(ref _OneDimensionalSampleModelsSorted, value); }
        #endregion

    }
}
