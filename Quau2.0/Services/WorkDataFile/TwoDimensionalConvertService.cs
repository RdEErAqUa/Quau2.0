using System.Collections.Generic;
using System.Linq;
using Quau2._0.Models.TwoDimensionalModels.BaseModels;
using Quau2._0.Services.WorkDataFile.Interfaces;

namespace Quau2._0.Services.WorkDataFile
{
    internal class TwoDimensionalConvertService : ITwoDimensionalConvertService
    {
        private readonly IOneDimensionalConvertService _OneDimensionalConvertService;
        private readonly IReadDataService _ReadDataService;
        private readonly ISaveDialogService _SaveDialogService;

        public TwoDimensionalConvertService(IReadDataService _readDataService, ISaveDialogService _saveDialogService,
            IOneDimensionalConvertService _oneDimensionalConverService)
        {
            _ReadDataService = _readDataService;
            _SaveDialogService = _saveDialogService;
            _OneDimensionalConvertService = _oneDimensionalConverService;
        }

        public ICollection<TwoDimensionalSampleModel> FromFileToTwoDimensionalData(string FilePath = null)
        {
            if (FilePath == null && _SaveDialogService.OpenFileDialog()) FilePath = _SaveDialogService.FilePath;

            return LineToTwoDimensionalData(_ReadDataService.ReadData(FilePath));
        }

        public ICollection<TwoDimensionalSampleModel> LineToTwoDimensionalData(string LineValue)
        {
            var OneDimensionalData = _OneDimensionalConvertService.LineToOneDimensionalData(LineValue);

            if (OneDimensionalData.Count % 2 != 0) return null;

            var TwoDimensionalData = new List<TwoDimensionalSampleModel>();

            for (var i = 0; i < OneDimensionalData.Count; i += 2)
                TwoDimensionalData.Add(new TwoDimensionalSampleModel
                    {X = OneDimensionalData.ElementAt(i), Y = OneDimensionalData.ElementAt(i + 1), Z = 0});

            return TwoDimensionalData;
        }
    }
}