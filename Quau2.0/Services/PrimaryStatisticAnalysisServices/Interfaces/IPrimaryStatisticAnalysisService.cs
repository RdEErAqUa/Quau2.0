using Quau2._0.Models.OneDimensionalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces
{
    interface IPrimaryStatisticAnalysisService
    {
        /// <summary>
        /// Сервис Class Size
        /// </summary>
        IClassSizeService classSizeService { get; set; }

        /// <summary>
        /// Установить значение размера класса
        /// </summary>
        /// <param name="OneDimData"></param>
        void ClassSizeSet(OneDimensionalModel OneDimData);
    }
}
