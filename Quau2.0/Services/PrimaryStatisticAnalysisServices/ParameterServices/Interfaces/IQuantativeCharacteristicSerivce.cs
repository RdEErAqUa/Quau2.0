using System.Collections.Generic;
using Quau2._0.Models.OneDimensionalModels;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.ParameterServices.Interfaces
{
    internal interface IQuantativeCharacteristicSerivce
    {
        void BuildQuantativeCharacteristic(OneDimensionalModel oneDimensionalModel, double a = 0.95);

        /// <summary>
        ///     Центральний момент
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        double CentralMoment(ICollection<double> data, int power);

        /// <summary>
        ///     Базова кількістна характеристика
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <param name="power"></param>
        /// <returns></returns> 
        public double InitialStaticMoment(ICollection<double> data, int power);

        /// <summary>
        ///     Середнє арифметичне
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <returns></returns>
        double Average(ICollection<double> data);

        /// <summary>
        ///     Середньоквадратичне значення/Дисперсія
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <returns></returns>
        double Dispersion(ICollection<double> data);

        /// <summary>
        ///     Середньоквадратичне відхилення/Дисперсія незсунена
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        double DispersionUnshifted(ICollection<double> data);

        /// <summary>
        ///     Коефіцієнт асиметрії(зсунений)
        /// </summary>
        /// <param name="oneDimensionalModel"></param>
        /// <returns></returns>
        double Skewness(ICollection<double> data);

        /// <summary>
        ///     Коефіцієнт асиметрії(незсуненний)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double SkewnessUnShifted(ICollection<double> value);

        /// <summary>
        ///     Коефіцієнт ексцесу
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double Kurtosis(ICollection<double> value);

        /// <summary>
        /// Коефіцієнт ексцесу незсунений
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double KurtosisUnshifted(ICollection<double> value);

        /// <summary>
        ///     Коефіцієнт контрексцесу
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double CounterKurtosis(ICollection<double> value);

        /// <summary>
        ///     Медіана абсолютних значень
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double MAD(ICollection<double> value);

        /// <summary>
        ///     Медіана середніх Уолша
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        double MED(ICollection<double> value);
    }
}