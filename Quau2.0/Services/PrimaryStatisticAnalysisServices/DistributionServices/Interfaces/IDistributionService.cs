using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.OneDimensionalModels.BaseModels;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.DistributionServices.Interfaces
{
    interface IDistributionService
    {
        /// <summary>
        ///     Построить график плотности за заднанным распределением
        /// </summary>
        /// <param name="model">Выборка</param>
        /// <param name="destribution">Выбранное распределение(0 - нормальное, 1 - экспоненциальное, 2 - равномерное, 3 - вейбулла, 4 - Акрсинуса, 5 - Релея,
        /// 6 - Логарифмическое-нормальное, 7 -  Лапласа
        /// )</param>
        /// <returns>Возвращает коллекцию точек распределения</returns>
        ObservableCollection<OneDimensionalSampleModel> DensityDistributionBuild(OneDimensionalModel model, int destribution = 0);

        /// <summary>
        ///     Построить график вероятности за заднанным распределением
        /// </summary>
        /// <param name="model">Выборка</param>
        /// <param name="destribution">Выбранное распределение(0 - нормальное, 1 - экспоненциальное, 2 - равномерное, 3 - вейбулла, 4 - Акрсинуса, 5 - Релея,
        /// 6 - Логарифмическое-нормальное, 7 -  Лапласа
        /// )</param>
        /// <returns>Возвращает коллекцию точек распределения</returns>
        ObservableCollection<OneDimensionalSampleModel> ProbabilityDistributionBuild(OneDimensionalModel model, int destribution = 0);
    }
}
