using System;
using System.Collections.ObjectModel;
using Quau2._0.Models.OneDimensionalModels.BaseModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices
{
    internal class ClassSizeService : IClassSizeService
    {
        public double SizeClassesFind(ObservableCollection<OneDimensionalSampleModel> OneDimSample)
        {
            if (OneDimSample.Count < 100)
                switch (OneDimSample.Count % 2)
                {
                    case 0:
                        return Math.Sqrt(OneDimSample.Count) - 1;
                    case 1:
                        return Math.Sqrt(OneDimSample.Count);
                }
            else
                switch (OneDimSample.Count % 2)
                {
                    case 0:
                        return Math.Pow(OneDimSample.Count, 1.0 / 3.0) - 1;
                    case 1:
                        return Math.Pow(OneDimSample.Count, 1.0 / 3.0);
                }

            return 0;
        }
    }
}