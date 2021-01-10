using Quau2._0.Models.OneDimensionalModels;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices.Interfaces
{
    internal interface IVariationSeriesService
    {
        void BuildVariation(OneDimensionalModel oneDimensionalSampleModel);
    }
}