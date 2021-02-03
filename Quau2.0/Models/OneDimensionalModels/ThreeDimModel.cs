using Quau2._0.Models.Base;

namespace Quau2._0.Models.OneDimensionalModels
{
    internal class ThreeDimModel : Model
    {
        #region X : double - варіанта

        private double _X;

        /// <summary>
        ///     Варіанта
        /// </summary>
        public double X
        {
            get => _X;
            set => Set(ref _X, value);
        }

        #endregion

        #region N : int - кількість варіант

        private int _N;

        /// <summary>
        ///     Кількість варіант
        /// </summary>
        public int N
        {
            get => _N;
            set => Set(ref _N, value);
        }

        #endregion

        #region P : double - частота варіанти

        private double _P;

        /// <summary>
        ///     Частота варіанти
        /// </summary>
        public double P
        {
            get => _P;
            set => Set(ref _P, value);
        }

        #endregion
    }
}