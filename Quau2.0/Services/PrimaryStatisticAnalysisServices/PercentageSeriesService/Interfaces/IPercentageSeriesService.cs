using Quau2._0.Models.OneDimensionalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService.Interfaces
{
    interface IPercentageSeriesService
    {

        /// <summary>
        /// Построить график плотности
        /// </summary>
        /// <param name="oneDimensionalSampleModel"></param>
        void DivisionInClass(OneDimensionalModel oneDimensionalSampleModel);
    }
}
