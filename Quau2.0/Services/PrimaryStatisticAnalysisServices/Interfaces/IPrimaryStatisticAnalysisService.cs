using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices.Interfaces;
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
        IClassSizeService classSizeService { get; }

        /// <summary>
        /// Сервис построение вариационого ряда
        /// </summary>
        IVariationSeriesService VariationSeriesService { get; }


        /// <summary>
        /// Начать первичный статистический анализ
        /// </summary>
        /// <param name="OneDimData"></param>
        void PrimaryAnalysisRun(OneDimensionalModel OneDimData);

        /// <summary>
        /// Установить значение размера класса
        /// </summary>
        /// <param name="OneDimData"></param>
        void ClassSizeSet(OneDimensionalModel OneDimData);

        /// <summary>
        /// Построение вариационого ряда
        /// </summary>
        /// <param name="OneDimData"></param>
        void BuildPrimaryVariation(OneDimensionalModel OneDimData);

        /// <summary>
        /// Построить статистические характеристики
        /// </summary>
        /// <param name="OneDimData"></param>
        void BuildQuantativeCharachteristics(OneDimensionalModel OneDimData);
    }
}
