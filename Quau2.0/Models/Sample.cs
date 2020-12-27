using Quau2._0.Models.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Models
{
    class Sample : Model
    {
        #region SampleValue : - входная выборка
        private ObservableCollection<double> _SampleValue;
        public ObservableCollection<double> SampleValue { get => _SampleValue; set => Set(ref _SampleValue, value); }
        #endregion
    }

}
