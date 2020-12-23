using Quau2._0.Infrastructure.Commands;
using Quau2._0.Infrastructure.Commands.Base;
using Quau2._0.Models;
using Quau2._0.Services.Interfaces;
using Quau2._0.Services.WorkDataFile.Interfaces;
using Quau2._0.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quau2._0.ViewModels
{
    class MainViewModel : ViewModel
    {
        #region SampleData : ObservableCollection<Sample> - коллекция выборок, которые анализируються

        private ObservableCollection<Sample> _SampleData;

        public ObservableCollection<Sample> SampleData { get => _SampleData; set => Set(ref _SampleData, value); }

        #endregion
        public MainViewModel(IOneDimensionalConvertService OneDimensionalConverterService, ITwoDimensionalConvertService TwoDimensionalConvertService)
        {
        }
    }
}
