using System.Collections.ObjectModel;
using Quau2._0.Models.Base;
using Quau2._0.Models.OneDimensionalModels;

namespace Quau2._0.Models.ClusterModels
{
    /// <summary>
    ///     Кластерная модель однмерных выборок, для анализа группы одномерных выборок
    /// </summary>
    internal class OneDimClusterModel : Model
    {
        #region ClusterName : String - название конкретного кластера

        private string _ClusterName;

        /// <summary>
        ///     Название конкретного кластера
        /// </summary>
        public string ClusterName
        {
            get => _ClusterName;
            set
            {
                if (OneDimensionalModels != null)
                    foreach (var el in OneDimensionalModels)
                        el.FileName = el.FileName.Replace(_ClusterName, value);
                Set(ref _ClusterName, value);
            }
        }

        #endregion

        #region ShortDesc : String - краткое описание кластера

        private string _ShortDesc;

        /// <summary>
        ///     Краткое описание кластера
        /// </summary>
        public string ShortDesc
        {
            get => _ShortDesc;
            set => Set(ref _ShortDesc, value);
        }

        #endregion

        #region OneDimensionalModels : ObservableCollection<OneDimensionalModel> - кластер одномерных выборок

        private ObservableCollection<OneDimensionalModel> _OneDimensionalModels;

        /// <summary>
        ///     Кластер одномерных выборок
        /// </summary>
        public ObservableCollection<OneDimensionalModel> OneDimensionalModels
        {
            get => _OneDimensionalModels;
            set => Set(ref _OneDimensionalModels, value);
        }

        #endregion
    }
}