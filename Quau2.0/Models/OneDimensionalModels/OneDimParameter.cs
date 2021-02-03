using Quau2._0.Models.Base;

namespace Quau2._0.Models.OneDimensionalModels
{
    internal class OneDimParameter : Model
    {
        #region Name : string - название параметра

        private string _Name;

        /// <summary>
        ///     Название параметра
        /// </summary>
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        #endregion

        #region Value : double - значение  параметра

        private double _Value;

        /// <summary>
        ///     Значение параметра
        /// </summary>
        public double Value
        {
            get => _Value;
            set => Set(ref _Value, value);
        }

        #endregion

        #region MaxValue : double - верхня межа довірчого інтервала

        private double _MaxValue;

        /// <summary>
        ///     Верхня межа довірчого інтервала
        /// </summary>
        public double MaxValue
        {
            get => _MaxValue;
            set => Set(ref _MaxValue, value);
        }

        #endregion

        #region MinValue : double - нижня межа довірчого інтервала

        private double _MinValue;

        /// <summary>
        ///     Нижня межа довірчого інтервала
        /// </summary>
        public double MinValue
        {
            get => _MinValue;
            set => Set(ref _MinValue, value);
        }

        #endregion

        #region RootMeanSquareValue : double - среднее квадратическое параметра

        private double _RootMeanSquareValue;

        /// <summary>
        ///     Среднее квадратическое параметра
        /// </summary>
        public double RootMeanSquareValue
        {
            get => _RootMeanSquareValue;
            set => Set(ref _RootMeanSquareValue, value);
        }

        #endregion
    }
}