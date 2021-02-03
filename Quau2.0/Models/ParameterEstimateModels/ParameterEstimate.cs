using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.Base;

namespace Quau2._0.Models.ParameterEstimateModels
{
    class ParameterEstimate : Model
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

        #region Degree : ObservableCollection<double> - степени волности

        private ObservableCollection<double> _Degree;
        /// <summary>
        ///     Степени волности
        /// </summary>
        public ObservableCollection<double> Degree
        {
            get => _Degree;
            set => Set(ref _Degree, value);
        }

        #endregion

        #region ProbablilityP : double - вероятность

        private double _ProbabilityP;
        /// <summary>
        ///     Вероятность
        /// </summary>
        public double ProbabilityP
        {
            get => _ProbabilityP;
            set => Set(ref _ProbabilityP, value);
        }

        #endregion

        #region Significance : bool - значимость оценки

        private bool _Significance;
        /// <summary>
        ///     Значимость оценки
        /// </summary>
        public bool Significance
        {
            get => _Significance;
            set => Set(ref _Significance, value);
        }

        #endregion

        #region QuantileStatistic : double - значение для оценки значимости

        private bool _QuantileStatistic;
        /// <summary>
        ///     Значимость оценки
        /// </summary>
        public bool QuantileStatistic
        {
            get => _QuantileStatistic;
            set => Set(ref _QuantileStatistic, value);
        }

        #endregion

        #region Significance : bool - значение, которое сравнивается с QuantileStatistic

        private bool _SignificanceStatistic;
        /// <summary>
        ///     Значимость оценки
        /// </summary>
        public bool SignificanceStatistic
        {
            get => _SignificanceStatistic;
            set => Set(ref _SignificanceStatistic, value);
        }

        #endregion
    }
}
