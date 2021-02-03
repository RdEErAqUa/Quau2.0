using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.QuantileModels;

namespace Quau2._0.Services.WorkDataFile.JsonReaderServices.Interfaces
{
    interface IJsonReadService
    {
        ICollection<QuantileModel> Read(string FileName = null);
    }
}
