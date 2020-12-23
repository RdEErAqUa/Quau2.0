using Quau2._0.Models.TwoDimensionalModels.BaseModels;
using Quau2._0.Services.WorkDataFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.WorkDataFile
{
    class TwoDimensionalConvertService : ITwoDimensionalConvertService
    {
        private IReadDataService _ReadDataService;
        private ISaveDialogService _SaveDialogService;
        private IOneDimensionalConvertService _OneDimensionalConvertService;
        public TwoDimensionalConvertService(IReadDataService _readDataService, ISaveDialogService _saveDialogService, IOneDimensionalConvertService _oneDimensionalConverService)
        {
            this._ReadDataService = _readDataService;
            this._SaveDialogService = _saveDialogService;
            this._OneDimensionalConvertService = _oneDimensionalConverService;
        }
        public ICollection<TwoDimensionalSampleModel> FromFileToTwoDimensionalData(string FilePath = null)
        {
            if (FilePath == null && _SaveDialogService.OpenFileDialog()) FilePath = _SaveDialogService.FilePath;

            return LineToTwoDimensionalData(_ReadDataService.ReadData(FilePath));
        }
        public ICollection<TwoDimensionalSampleModel> LineToTwoDimensionalData(string LineValue)
        {
            var OneDimensionalData = this._OneDimensionalConvertService.LineToOneDimensionalData(LineValue);

            if (OneDimensionalData.Count % 2 != 0) return null;

            var TwoDimensionalData = new List<TwoDimensionalSampleModel> { };

            for (int i = 0; i < OneDimensionalData.Count; i += 2)
                TwoDimensionalData.Add(new TwoDimensionalSampleModel { X = OneDimensionalData.ElementAt(i), Y = OneDimensionalData.ElementAt(i + 1), Z = 0});

            return TwoDimensionalData;

        }
    }
}
