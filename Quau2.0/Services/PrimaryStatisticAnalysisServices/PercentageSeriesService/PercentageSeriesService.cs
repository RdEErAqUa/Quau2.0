using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService
{
    class PercentageSeriesService : IPercentageSeriesService
    {
        public void DivisionInClass(OneDimensionalModel oneDimensionalSampleModel)
        {
            var SampleDivisionData = new ObservableCollection<ThreeDimModel> { };
            //
            //
            List<double> xDivision = FindXDivision(oneDimensionalSampleModel);

            //

            List<int> xDivisionFrequency = FindFrequencyDivision(oneDimensionalSampleModel, xDivision);
            //

            List<double> RelativeFrequencyDivision = FindRelativeFrequencyDivision(oneDimensionalSampleModel, xDivisionFrequency);

            //
            for (int i = 0; i < xDivision.Count; i++) SampleDivisionData.Add(
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
            List<double> xDivision = new List<double> { };

            double stepSize = (oneDimensionalSampleModel.VariationData.Last().X - oneDimensionalSampleModel.VariationData.First().X) / (oneDimensionalSampleModel.ClassSize);

            oneDimensionalSampleModel.StepSize = stepSize;

            for (int i = 0; i <= oneDimensionalSampleModel.ClassSize; i++)
            {
                xDivision.Add((i) * stepSize + oneDimensionalSampleModel.VariationData.First().X);
            }
            return xDivision;
        }

        private List<int> FindFrequencyDivision(OneDimensionalModel oneDimensionalSampleModel, List<double> xDivision)
        {
            List<int> zFrequencyDivision = new List<int> { };


            for (int i = 0; i < xDivision.Count; i++)
            {
                int count = 0;
                foreach (var el in oneDimensionalSampleModel.VariationData)
                {
                    if (i == xDivision.Count - 1) continue;
                    else if (i == xDivision.Count - 2 && xDivision[i] <= el.X && xDivision[i + 1] >= el.X)
                    {
                        count += el.N;
                    }
                    else if (xDivision[i] <= el.X && xDivision[i + 1] > el.X)
                    {
                        count += el.N;
                    }

                }
                zFrequencyDivision.Add(count);
            }
            return zFrequencyDivision;
        }

        private List<double> FindRelativeFrequencyDivision(OneDimensionalModel oneDimensionalSampleModel, List<int> xDivisionFrequency)
        {
            List<double> RelativeFrequencyDivision = new List<double> { };

            foreach (var el in xDivisionFrequency)
            {
                RelativeFrequencyDivision.Add((double)el / (double)oneDimensionalSampleModel.OneDimensionalSampleModels.Count);
            }

            return RelativeFrequencyDivision; 
        }
    }
}
