using Quau2._0.Models.OneDimensionalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.HistogramSeriesServices.Interfaces
{
    interface IHistogramSeriesService
    {
        /// <summary>
        /// Построить данные для гистограмной оценки
        /// </summary>
        /// <param name="oneDimensionalSampleModel"></param>
        void CreateEmpiricalDataValue(OneDimensionalModel oneDimensionalSampleModel, int RoundValue = 0);
    }
}
