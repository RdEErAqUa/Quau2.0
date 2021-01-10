using System;
using System.Collections.ObjectModel;
using System.Linq;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.HistogramSeriesServices.Interfaces;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.HistogramSeriesServices
{
    internal class HistogramSeriesService : IHistogramSeriesService
    {
        public void CreateEmpiricalDataValue(OneDimensionalModel oneDimensionalSampleModel, int RoundValue = 0)
        {
            if (RoundValue <= 0 || RoundValue > 15) RoundValue = 15;
            var answer = new ObservableCollection<ThreeDimModel>();

            var pz = oneDimensionalSampleModel.PercentegData.First().P;

            answer.Add(new ThreeDimModel {X = oneDimensionalSampleModel.PercentegData.First().X, P = pz});
            foreach (var el in oneDimensionalSampleModel.PercentegData)
                if (el == oneDimensionalSampleModel.PercentegData.First())
                {
                }
                else
                {
                    pz += el.P;
                    answer.Add(new ThreeDimModel {X = Math.Round(el.X, RoundValue), P = Math.Round(pz, RoundValue)});
                }

            var testP = 0.0;
            foreach (var el in oneDimensionalSampleModel.PercentegData)
                testP += el.P;

            oneDimensionalSampleModel.HistogramData = answer;
        }
    }
}