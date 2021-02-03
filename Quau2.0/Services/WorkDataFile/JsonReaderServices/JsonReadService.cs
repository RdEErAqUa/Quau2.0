using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Quau2._0.Models.QuantileModels;
using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.Services.WorkDataFile.JsonReaderServices.Interfaces;

namespace Quau2._0.Services.WorkDataFile.JsonReaderServices
{
    class JsonReadService : IJsonReadService
    {
        private ISaveDialogService _saveDialogService;
        private IReadDataService _readDataService;

        public JsonReadService(ISaveDialogService saveDialogService, IReadDataService readDataService)
        {
            _readDataService = readDataService;
            _saveDialogService = saveDialogService;
        }

        public ICollection<QuantileModel> Read(string FileName = null)
        {
            if (FileName == null && _saveDialogService.OpenFileDialog()) FileName = _saveDialogService.FilePath;

            var value = _readDataService.ReadData(FileName);

            return JsonSerializer.Deserialize< ICollection < QuantileModel >> (value);
        }
    }
}
