using System.Collections.ObjectModel;
using Quau2._0.Models.OneDimensionalModels.BaseModels;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces
{
    internal interface IClassSizeService
    {
        /// <summary>
        ///     Установить размер класса
        /// </summary>
        /// <param name="OneDimSample"></param>
        /// <returns></returns>
        double SizeClassesFind(ObservableCollection<OneDimensionalSampleModel> OneDimSample);
    }
}