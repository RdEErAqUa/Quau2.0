using Quau2._0.Models.ClusterModels;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.TwoDimensionalModels;
using Quau2._0.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.ViewModels.PreviewViewModels
{
    class PreviewViewModel : ViewModel
    {

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

        /// <summary>
        /// Конструктор модели для DependencyInjection
        /// </summary>
        public PreviewViewModel()
        {

        }

        /// <summary>
        /// Конструктор модели для конструктора VisualStudio
        /// </summary>
    }
}
