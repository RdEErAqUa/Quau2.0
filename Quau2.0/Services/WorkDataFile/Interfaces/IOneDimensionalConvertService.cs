﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.WorkDataFile.Interfaces
{
    interface IOneDimensionalConvertService
    {
        /// <summary>
        /// Класс считывает данные выборки из строки LineValue, и преобразовывает его в одномерную выборку.
        /// </summary>
        ICollection<double> LineToOneDimensionalData(string LineValue);

        /// <summary>
        /// Класс считывает данные выборки из файла FilePath, и преобразовывает его в одномерную выборку.
        /// Если FilePath не задана как параметр, открывается диалговое окно для выбора файла.
        /// </summary>
        ICollection<double> FromFileToOneDimensionalData(string FilePath = null);
    }
}
