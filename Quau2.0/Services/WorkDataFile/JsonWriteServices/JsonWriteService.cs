using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Quau2._0.Models.QuantileModels;
using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.Services.WorkDataFile.JsonWriteServices.Interfaces;

namespace Quau2._0.Services.WorkDataFile.JsonWriteServices
{
    class JsonWriteService : IJsonWriteService
    {
        private ISaveDialogService _saveDialogService;
        private IReadDataService _readDataService;

        public JsonWriteService(ISaveDialogService saveDialogService, IReadDataService readDataService)
        {
            _readDataService = readDataService;
            _saveDialogService = saveDialogService;
        }

        public bool Write(ICollection<QuantileModel> valueModel, string FileName = null)
        {
            if (FileName == null && _saveDialogService.OpenFileDialog()) FileName = _saveDialogService.FilePath;

            var value = JsonSerializer.Serialize(valueModel);

            using (var file = new StreamWriter(FileName))
            {
                file.Write(value);
            }

            return true;
        }
    }
}
