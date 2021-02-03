using System;
using System.Collections.Generic;
using System.Linq;
using Quau2._0.Services.WorkDataFile.Interfaces;

namespace Quau2._0.Services.WorkDataFile
{
    internal class OneDimensionalConvertService : IOneDimensionalConvertService
    {
        private readonly IReadDataService _ReadDataService;
        private readonly ISaveDialogService _SaveDialogService;

        public OneDimensionalConvertService(IReadDataService _readDataService, ISaveDialogService _saveDialogService)
        {
            _ReadDataService = _readDataService;
            _SaveDialogService = _saveDialogService;
        }

        public ICollection<double> FromFileToOneDimensionalData(string FilePath = null)
        {
            if (FilePath == null && _SaveDialogService.OpenFileDialog()) FilePath = _SaveDialogService.FilePath;

            return LineToOneDimensionalData(_ReadDataService.ReadData(FilePath));
        }

        public ICollection<double> LineToOneDimensionalData(string LineValue)
        {
            if (LineValue == null) return null;

            char[] separator = {' ', '\n', '\r'};
            try
            {
                LineValue = LineValue.Replace('\n', ' ');
                LineValue = LineValue.Replace('.', ',');
                var OneDimensionalData = LineValue.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(x => double.Parse(x)).ToArray().ToList();

                return OneDimensionalData;
            }
            catch (FormatException)
            {
                return null;
            }
        }
    }
}