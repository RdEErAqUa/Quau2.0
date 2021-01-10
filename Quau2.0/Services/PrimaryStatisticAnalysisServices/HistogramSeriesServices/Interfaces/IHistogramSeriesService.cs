using Quau2._0.Models.OneDimensionalModels;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.HistogramSeriesServices.Interfaces
{
    internal interface IHistogramSeriesService
    {
        /// <summary>
        ///     Построить данные для гистограмной оценки
        /// </summary>
        /// <param name="oneDimensionalSampleModel"></param>
        void CreateEmpiricalDataValue(OneDimensionalModel oneDimensionalSampleModel, int RoundValue = 0);
    }
}