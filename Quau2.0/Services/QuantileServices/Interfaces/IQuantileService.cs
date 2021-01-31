using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.QuantileServices.Interfaces
{
    interface IQuantileService
    {
        /// <summary>
        ///     Считать квантили с файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        void ReadValueQuantile(string fileName = null);
        /// <summary>
        ///     Записать квантили в файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        void WriteValueQuantile(string fileName = null);
        /// <summary>
        ///     t - квантиль(t - статистика), с a, v
        /// </summary>
        /// <param name="a"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public double getT(double a, int v);
        /// <summary>
        ///     U - квантиль с a
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        double getU(double a);
        /// <summary>
        ///     Xi - квантиль с a, v
        /// </summary>
        /// <param name="a"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        double getX(double a, int v);
        /// <summary>
        ///     f-квантиль с a, v1, v2 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        double getF(double a, int v1, int v2);
    }
}
