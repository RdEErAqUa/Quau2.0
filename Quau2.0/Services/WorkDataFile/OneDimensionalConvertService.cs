using Quau2._0.Services.WorkDataFile.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.WorkDataFile
{
    class OneDimensionalConvertService : IOneDimensionalConvertService
    {
        private IReadDataService _ReadDataService;
        private ISaveDialogService _SaveDialogService;
        public OneDimensionalConvertService(IReadDataService _readDataService, ISaveDialogService _saveDialogService)
        {
            this._ReadDataService = _readDataService;
            this._SaveDialogService = _saveDialogService;
        }
        public ICollection<double> FromFileToOneDimensionalData(string FilePath = null)
        {
            if (FilePath == null && _SaveDialogService.OpenFileDialog()) FilePath = _SaveDialogService.FilePath;

            return LineToOneDimensionalData(_ReadDataService.ReadData(FilePath));
        }
        public ICollection<double> LineToOneDimensionalData(string LineValue)
        {
            if (LineValue == null) return null;

            char[] separator = new char[] { ' ', '\n', '\r' };
            try
            {
                LineValue = LineValue.Replace('\n', ' ');
                LineValue = LineValue.Replace('.', ',');
                var OneDimensionalData = LineValue.Split(' ').
                        Where(x => !string.IsNullOrWhiteSpace(x)).
                        Select(x => double.Parse(x)).ToArray().ToList();

                return OneDimensionalData;
            }
            catch (System.FormatException)
            {
                return null;
            }
        }
    }
}
