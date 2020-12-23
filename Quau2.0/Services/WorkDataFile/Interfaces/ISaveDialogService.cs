using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.WorkDataFile.Interfaces
{
    interface ISaveDialogService
    {
        /// <summary>
        /// Путь к файлу, который пользователь выбрал в диалоговом окне.
        /// </summary>
        string FilePath { get; set; }

        /// <summary>
        /// Открывает диалоговое окно для выбора пути к файлу.
        /// </summary>
        bool OpenFileDialog();
    }
}
