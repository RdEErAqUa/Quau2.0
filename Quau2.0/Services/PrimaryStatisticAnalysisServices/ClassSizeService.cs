using Quau2._0.Models.OneDimensionalModels.BaseModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices
{
    class ClassSizeService : IClassSizeService
    {
        public double SizeClassesFind(ObservableCollection<OneDimensionalSampleModel> OneDimSample)
        {

            if (OneDimSample.Count < 100)
            {
                switch (OneDimSample.Count % 2)
                {
                    case 0:
                        return Math.Sqrt(OneDimSample.Count) - 1;
                    case 1:
                        return Math.Sqrt(OneDimSample.Count);
                    default:
                        break;
                }
            }
            else
            {
                switch (OneDimSample.Count % 2)
                {
                    case 0:
                        return Math.Pow(OneDimSample.Count, 1.0 / 3.0) - 1;
                    case 1:
                        return Math.Pow(OneDimSample.Count, 1.0 / 3.0);
                    default:
                        break;
                }
            }
            return 0;
        }
    }
}
