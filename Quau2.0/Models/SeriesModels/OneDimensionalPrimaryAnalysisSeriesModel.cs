using LiveCharts;
using Quau2._0.Models.Base;

namespace Quau2._0.Models.SeriesModels
{
    internal class OneDimensionalPrimaryAnalysisSeriesModel : Model
    {
        #region OneDimensionalSeries : SeriesCollection - серия одномерных выборок, для функции плотности

        private SeriesCollection _OneDimensionalSeries;

        /// <summary>
        ///     Серия одномерных выборок, для функции плотности
        /// </summary>
        public SeriesCollection OneDimensionalSeries
        {
            get => _OneDimensionalSeries;
            set => Set(ref _OneDimensionalSeries, value);
        }

        #endregion

        #region OneDimensionalSeriesProbability : SeriesCollection - серия одномерных выборок, для функции вероятности

        private SeriesCollection _OneDimensionalSeriesProbability;

        /// <summary>
        ///     Серия одномерных выборок, для функции вероятности
        /// </summary>
        public SeriesCollection OneDimensionalSeriesProbability
        {
            get => _OneDimensionalSeriesProbability;
            set => Set(ref _OneDimensionalSeriesProbability, value);
        }

        #endregion
    }
}