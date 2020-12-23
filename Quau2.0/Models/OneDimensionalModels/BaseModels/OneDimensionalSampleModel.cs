using Quau2._0.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Models.OneDimensionalModels.BaseModels
{
    class OneDimensionalSampleModel : Model
    {
        #region X : double - значение абсцисса на данных {xi, yi}
        private double _X;

        public double X { get => _X; set => Set(ref _X, value); }
        #endregion

        #region Y : double - значение ординат на данных {xi, yi}
        private double _Y;

        public double Y { get => _Y; set => Set(ref _Y, value); }
        #endregion
    }
}
