using OxyPlot;
using Model = Quau2._0.Models.Base.Model;

namespace Quau2._0.Models.SeriesModels
{
    internal class OneDimensionalPrimaryAnalysisSeriesModel : Model
    {
        #region OneDimensionalSeries : SeriesCollection - серия одномерных выборок, для функции плотности

        private PlotModel _OneDimensionalSeries;

        /// <summary>
        ///     Серия одномерных выборок, для функции плотности
        /// </summary>
        public PlotModel OneDimensionalSeries
        {
            get => _OneDimensionalSeries;
            set => Set(ref _OneDimensionalSeries, value);
        }

        #endregion

        #region OneDimensionalSeriesProbability : SeriesCollection - серия одномерных выборок, для функции вероятности

        private PlotModel _OneDimensionalSeriesProbability;

        /// <summary>
        ///     Серия одномерных выборок, для функции вероятности
        /// </summary>
        public PlotModel OneDimensionalSeriesProbability
        {
            get => _OneDimensionalSeriesProbability;
            set => Set(ref _OneDimensionalSeriesProbability, value);
        }

        #endregion
    }
}