using Quau2._0.Models.OneDimensionalModels;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService.Interfaces
{
    internal interface IPercentageSeriesService
    {
        /// <summary>
        ///     Построить график плотности
        /// </summary>
        /// <param name="oneDimensionalSampleModel"></param>
        void DivisionInClass(OneDimensionalModel oneDimensionalSampleModel);
    }
}