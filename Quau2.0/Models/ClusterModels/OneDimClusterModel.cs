using Quau2._0.Models.Base;
using Quau2._0.Models.OneDimensionalModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Models.ClusterModels
{
    /// <summary>
    /// Кластерная модель однмерных выборок, для анализа группы одномерных выборок
    /// </summary>
    class OneDimClusterModel : Model
    {
        #region ClusterName : String - название конкретного кластера

        private String _ClusterName;
        /// <summary>
        /// Название конкретного кластера
        /// </summary>
        public String ClusterName { get => _ClusterName; set => Set(ref _ClusterName, value); }

        #endregion

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - кластер одномерных выборок
        private ObservableCollection<OneDimensionalModel> _OneDimensionalModels;
        /// <summary>
        /// Кластер одномерных выборок
        /// </summary>
        public ObservableCollection<OneDimensionalModel> OneDimensionalModels { get => _OneDimensionalModels; set => Set(ref _OneDimensionalModels, value); }

        #endregion
    }
}
