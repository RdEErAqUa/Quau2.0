using Quau2._0.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Models.OneDimensionalModels
{
    class OneDimParameter : Model
    {
        #region ParamName : string - название параметра

        private String _ParamName;

        /// <summary>
        /// Название параметра
        /// </summary>
        public String ParamName { get => _ParamName; set => Set(ref _ParamName, value); }

        #endregion

        #region ParamValue : double - значение  параметра

        private double _ParamValue;
        /// <summary>
        /// Значение параметра
        /// </summary>
        public double ParamValue { get => _ParamValue; set => Set(ref _ParamValue, value); }

        #endregion

        #region MaxParamValue : double - верхня межа довірчого інтервала

        private double _MaxParamValue;
        /// <summary>
        /// Верхня межа довірчого інтервала
        /// </summary>
        public double MaxParamValue { get => _MaxParamValue; set => Set(ref _MaxParamValue, value); }

        #endregion

        #region MinParamValue : double - нижня межа довірчого інтервала

        private double _MinParamValue;
        /// <summary>
        /// Нижня межа довірчого інтервала
        /// </summary>
        public double MinParamValue { get => _MinParamValue; set => Set(ref _MinParamValue, value); }

        #endregion

        #region RootMeanSquareValue : double - среднее квадратическое параметра

        private double _RootMeanSquareValue;
        /// <summary>
        /// Среднее квадратическое параметра 
        /// </summary>
        public double RootMeanSquareValue { get => _RootMeanSquareValue; set => Set(ref _RootMeanSquareValue, value); }

        #endregion
    }
}
