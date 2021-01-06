using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.OneDimensionalModels.BaseModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices
{
    class VariationSeriesService : IVariationSeriesService
    {
        public void BuildVariation(OneDimensionalModel oneDimensionalSampleModel)
        {
            var SampleRankingData = new ObservableCollection<ThreeDimModel> { };

            List<double> dataSample = removeEqualse(oneDimensionalSampleModel.OneDimensionalSampleModelsSorted.Select(X => X.X).ToList());

            //

            List<int> dataSampleFrequency = findDataFrequency(dataSample, oneDimensionalSampleModel.OneDimensionalSampleModelsSorted.Select(X => X.X).ToList());
            //

            List<double> DataRelativeFrequency = findDataRelativeFrequency(dataSampleFrequency);

            for (int i = 0; i < dataSample.Count; i++) SampleRankingData.Add(
                 new ThreeDimModel
                 {
                     X = dataSample[i],
                     N = dataSampleFrequency[i],
                     P = DataRelativeFrequency[i]
                 });
            oneDimensionalSampleModel.VariationData = new ObservableCollection<ThreeDimModel>(SampleRankingData);
        }

        static private List<double> removeEqualse(ICollection<double> value)
        {
            List<double> returnValue = new List<double> { };

            foreach (var el in value)
            {
                if (!returnValue.Contains(el)) returnValue.Add(el);
            }
            return returnValue;
        }

        static private List<int> findDataFrequency(ICollection<double> value, ICollection<double> valueIN)
        {
            List<int> dataFrequency = new List<int> { };
            foreach (var el in value)
            {
                int count = 0;
                foreach (var el2 in valueIN)
                {
                    if (el == el2) count++;
                }
                dataFrequency.Add(count);
            }

            return dataFrequency;
        }

        static private List<double> findDataRelativeFrequency(ICollection<int> dataSampleFrequency)
        {
            List<double> DataRelativeFrequency = new List<double> { };
            double size = 0;

            foreach (var el in dataSampleFrequency) size += el;

            foreach (var el in dataSampleFrequency) DataRelativeFrequency.Add(el / size);

            return DataRelativeFrequency;
        }
    }
}
