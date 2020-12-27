using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.WorkDataFile.Interfaces
{
    interface IReadDataService
    {
        /// <summary>
        /// Класс считывает данные из файла по пути PATH как строку.
        /// </summary>
        string ReadData(String PATH);
    }
}
