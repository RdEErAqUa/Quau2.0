using Quau2._0.Models.Base;

namespace Quau2._0.Models.TwoDimensionalModels.BaseModels
{
    internal class TwoDimensionalSampleModel : Model
    {
        #region X : double - значение абсцисса на данных {xi, yi, zi}

        private double _X;

        public double X
        {
            get => _X;
            set => Set(ref _X, value);
        }

        #endregion

        #region Y : double - значение ординат на данных {xi, yi, zi}

        private double _Y;

        public double Y
        {
            get => _Y;
            set => Set(ref _Y, value);
        }

        #endregion

        #region Z : double - значение z - координаты, для заданых Xi та Yi на данных {xi, yi, zi}

        private double _Z;

        public double Z
        {
            get => _Z;
            set => Set(ref _Z, value);
        }

        #endregion
    }
}