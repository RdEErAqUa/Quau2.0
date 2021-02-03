using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService.Interfaces;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService
{
    internal class PercentageSeriesService : IPercentageSeriesService
    {
        public void DivisionInClass(OneDimensionalModel oneDimensionalSampleModel)
        {
            var SampleDivisionData = new ObservableCollection<ThreeDimModel>();
            //
            //
            var xDivision = FindXDivision(oneDimensionalSampleModel);

            //

            var xDivisionFrequency = FindFrequencyDivision(oneDimensionalSampleModel, xDivision);
            //

            var RelativeFrequencyDivision =
                FindRelativeFrequencyDivision(oneDimensionalSampleModel, xDivisionFrequency);

            //
            for (var i = 0; i < xDivision.Count; i++)
                SampleDivisionData.Add(
                    new ThreeDimModel
                    {
                        X = xDivision[i],
                        N = xDivisionFrequency[i],
                        P = RelativeFrequencyDivision[i]
                    });

            oneDimensionalSampleModel.PercentegData = new ObservableCollection<ThreeDimModel>(SampleDivisionData);
        }

        private List<double> FindXDivision(OneDimensionalModel oneDimensionalSampleModel)
        {
            var xDivision = new List<double>();

            var stepSize =
                (oneDimensionalSampleModel.VariationData.Last().X - oneDimensionalSampleModel.VariationData.First().X) /
                oneDimensionalSampleModel.ClassSize;

            oneDimensionalSampleModel.StepSize = stepSize;

            for (var i = 0; i <= oneDimensionalSampleModel.ClassSize; i++)
                xDivision.Add(i * stepSize + oneDimensionalSampleModel.VariationData.First().X);
            return xDivision;
        }

        private List<int> FindFrequencyDivision(OneDimensionalModel oneDimensionalSampleModel, List<double> xDivision)
        {
            var zFrequencyDivision = new List<int>();


            for (var i = 0; i < xDivision.Count; i++)
            {
                var count = 0;
                foreach (var el in oneDimensionalSampleModel.VariationData)
                    if (i == xDivision.Count - 1) continue;
                    else if (i == xDivision.Count - 2 && xDivision[i] <= el.X && xDivision[i + 1] >= el.X)
                        count += el.N;
                    else if (xDivision[i] <= el.X && xDivision[i + 1] > el.X) count += el.N;
                zFrequencyDivision.Add(count);
            }

            return zFrequencyDivision;
        }

        private List<double> FindRelativeFrequencyDivision(OneDimensionalModel oneDimensionalSampleModel,
            List<int> xDivisionFrequency)
        {
            var RelativeFrequencyDivision = new List<double>();

            foreach (var el in xDivisionFrequency)
                RelativeFrequencyDivision.Add(el / (double) oneDimensionalSampleModel.OneDimensionalSampleModels.Count);

            return RelativeFrequencyDivision;
        }
    }
}