using System.Collections.Generic;
using Quau2._0.Models.TwoDimensionalModels.BaseModels;

namespace Quau2._0.Services.WorkDataFile.Interfaces
{
    internal interface ITwoDimensionalConvertService
    {
        /// <summary>
        ///     Класс считывает данные выборки из строки LineValue, и преобразовывает его в двомерную выборку выборку.
        ///     (xi, yi). Где первый елемент в строке - x0, второй - y0. И так далее
        /// </summary>
        ICollection<TwoDimensionalSampleModel> LineToTwoDimensionalData(string LineValue);

        /// <summary>
        ///     Класс считывает данные выборки из файла FilePath, и преобразовывает его в двомерную выборку выборку.
        ///     (xi, yi). Где первый елемент в строке - x0, второй - y0. И так далее
        ///     Если FilePath не задана как параметр, открывается диалговое окно для выбора файла.
        /// </summary>
        ICollection<TwoDimensionalSampleModel> FromFileToTwoDimensionalData(string FilePath = null);
    }
}