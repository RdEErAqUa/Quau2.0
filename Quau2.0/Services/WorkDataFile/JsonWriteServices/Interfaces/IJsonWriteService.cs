using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.QuantileModels;

namespace Quau2._0.Services.WorkDataFile.JsonWriteServices.Interfaces
{
    interface IJsonWriteService
    {
        bool Write(ICollection<QuantileModel> valueDictionary, string FileName = null);
    }
}
