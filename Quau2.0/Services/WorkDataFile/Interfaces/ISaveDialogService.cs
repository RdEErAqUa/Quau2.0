﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.WorkDataFile.Interfaces
{
    interface ISaveDialogService
    {
        string FilePath { get; set; }

        bool OpenFileDialog();
    }
}
