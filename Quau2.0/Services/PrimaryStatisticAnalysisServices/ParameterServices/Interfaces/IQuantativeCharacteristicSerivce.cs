using System.Collections.Generic;
using Quau2._0.Models.OneDimensionalModels;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.ParameterServices.Interfaces
{
    internal interface IQuantativeCharacteristicSerivce
    {
        void BuildQuantativeCharacteristic(OneDimensionalModel oneDimensionalModel);

        /// <summary>
        ///     Центральний момент
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        double CentralMoment(IEnumerable<double> data, int power);

        /// <summary>
        ///     Базова кількістна характеристика
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public double InitialStaticMoment(IEnumerable<double> data, int power);

        /// <summary>
        ///     Середнє арифметичне
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <returns></returns>
        double Average(IEnumerable<double> data);

        /// <summary>
        ///     Середньоквадратичне значення
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <returns></returns>
        double SquareAverage(IEnumerable<double> data);

        /// <summary>
        ///     Коефіцієнт асиметрії(незсуненний)
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <returns></returns>
        double Skewness(IEnumerable<double> data);
    }
}