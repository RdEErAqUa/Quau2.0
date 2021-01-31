using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.Base;

namespace Quau2._0.Models.QuantileModels
{
    class QuantileModel : Model
    {
        #region Name : string - название квантиля

        private string _Name;

        /// <summary>
        ///     Назва квантиля
        /// </summary>
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        #endregion

        #region Parameters : double[] - параметри

        private double[] _Parameters;

        /// <summary>
        ///     Параметри квантиля
        /// </summary>
        public double[] Parameters
        {
            get => _Parameters;
            set => Set(ref _Parameters, value);
        }

        #endregion

        #region Value : double - значение квантиля

        private double _Value;

        /// <summary>
        ///     Значение квантиля
        /// </summary>
        public double Value
        {
            get => _Value;
            set => Set(ref _Value, value);
        }

        #endregion
    }
}
