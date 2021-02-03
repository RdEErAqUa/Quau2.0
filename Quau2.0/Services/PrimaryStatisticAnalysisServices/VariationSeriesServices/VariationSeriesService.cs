using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices.Interfaces;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices
{
    internal class VariationSeriesService : IVariationSeriesService
    {
        public void BuildVariation(OneDimensionalModel oneDimensionalSampleModel)
        {
            var SampleRankingData = new ObservableCollection<ThreeDimModel>();

            var dataSample =
                removeEqualse(oneDimensionalSampleModel.OneDimensionalSampleModelsSorted.Select(X => X.X).ToList());

            //

            var dataSampleFrequency = findDataFrequency(dataSample,
                oneDimensionalSampleModel.OneDimensionalSampleModelsSorted.Select(X => X.X).ToList());
            //

            var DataRelativeFrequency = findDataRelativeFrequency(dataSampleFrequency);

            for (var i = 0; i < dataSample.Count; i++)
                SampleRankingData.Add(
                    new ThreeDimModel
                    {
                        X = dataSample[i],
                        N = dataSampleFrequency[i],
                        P = DataRelativeFrequency[i]
                    });
            oneDimensionalSampleModel.VariationData = new ObservableCollection<ThreeDimModel>(SampleRankingData);
        }

        private static List<double> removeEqualse(ICollection<double> value)
        {
            var returnValue = new List<double>();

            foreach (var el in value)
                if (!returnValue.Contains(el))
                    returnValue.Add(el);
            return returnValue;
        }

        private static List<int> findDataFrequency(ICollection<double> value, ICollection<double> valueIN)
        {
            var dataFrequency = new List<int>();
            foreach (var el in value)
            {
                var count = 0;
                foreach (var el2 in valueIN)
                    if (el == el2)
                        count++;
                dataFrequency.Add(count);
            }

            return dataFrequency;
        }

        private static List<double> findDataRelativeFrequency(ICollection<int> dataSampleFrequency)
        {
            var DataRelativeFrequency = new List<double>();
            double size = 0;

            foreach (var el in dataSampleFrequency) size += el;

            foreach (var el in dataSampleFrequency) DataRelativeFrequency.Add(el / size);

            return DataRelativeFrequency;
        }
    }
}