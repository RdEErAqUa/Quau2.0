using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.Base;
using Quau2._0.Models.OneDimensionalModels.BaseModels;
using Quau2._0.Models.ParameterEstimateModels;

namespace Quau2._0.Models.OneDimensionalModels.DistributionModels
{
    class DistributionModel : Model
    {
        #region Name : string - Название распределения

        private string _Name;

        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        #endregion

        #region DataProbability : ObservableCollection<OneDimensionalSampleModel> - данные распределения

        private ObservableCollection<OneDimensionalSampleModel> _DataProbability;

        public ObservableCollection<OneDimensionalSampleModel> DataProbability
        {
            get => _DataProbability;
            set => Set(ref _DataProbability, value);
        }

        #endregion

        #region DataProbability : ObservableCollection<OneDimensionalSampleModel> - данные распределения

        private ObservableCollection<OneDimensionalSampleModel> _DataDensity;

        public ObservableCollection<OneDimensionalSampleModel> DataDensity
        {
            get => _DataDensity;
            set => Set(ref _DataDensity, value);
        }

        #endregion

        #region VarianceDenstiy : double -  дисперсія статистичної функції розподілу ймовірностей

        private double _VarianceDenstiy;

        public double VarianceDensity { get => _VarianceDenstiy; set => Set(ref _VarianceDenstiy, value); }

        #endregion

        #region ConsentTest : ObservableCollection<ParameterEstimate> - оценки тестов

        private ObservableCollection<ParameterEstimate> _Parameter;

        public ObservableCollection<ParameterEstimate> Parameter
        {
            get => _Parameter;
            set => Set(ref _Parameter, value);
        }

        #endregion
    }
}
