using Quau2._0.Models.OneDimensionalModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces
{
    interface IClassSizeService
    {
        /// <summary>
        /// Установить размер класса
        /// </summary>
        /// <param name="OneDimSample"></param>
        /// <returns></returns>
        double SizeClassesFind(ObservableCollection<OneDimensionalSampleModel> OneDimSample);
    }
}
