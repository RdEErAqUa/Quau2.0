using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.Infrastructure.Commands.AsyncLambdaCommands
{
    class ReadDataFromFileCommand
    {
        private bool _isBusyReadDataFromFile;
        public bool isBusyReadDataFromFile
        {
            get => _isBusyReadDataFromFile;
            private set => Set(ref _isBusyReadDataFromFile, value);
        }

        public ICommand ReadDataFromFile { get; private set; }
        private async Task OnReadDataFromFileExecuted(object p)
        {
            try
            {
                isBusyReadDataFromFile = true;
                await Task.Run(() =>
                {
                    switch (Int32.Parse((string)p))
                    {
                        //Случай, считывание данных как двомерные данные и одномерные данные
                        case 0:
                            break;
                        //Случай, считывание данных как одномерные данные
                        case 1:
                            OneDimensionalModels.Add(new OneDimensionalModel
                            {
                                OneDimensionalSampleModels =
                                new ObservableCollection<Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel>(_OneDimensionalConverterService.
                                FromFileToOneDimensionalData().
                                Select(X => new Models.OneDimensionalModels.BaseModels.OneDimensionalSampleModel { X = X, Y = 0 }))
                            });
                            break;
                        //Случай, считывание данных как двомерные данные
                        case 2:
                            _TwoDimensionalConvertService.FromFileToTwoDimensionalData();
                            break;
                    }
                });
            }
            finally
            {
                isBusyReadDataFromFile = false;
            }
        }

        private bool CanReadDataFromFileExecute(object p)
        {
            return !isBusyReadDataFromFile;
        }
    }
}
