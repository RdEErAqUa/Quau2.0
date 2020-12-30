using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.HistogramSeriesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.HistogramSeriesServices
{
    class HistogramSeriesService : IHistogramSeriesService
    {
        public void CreateEmpiricalDataValue(OneDimensionalModel oneDimensionalSampleModel, int RoundValue = 0)
        {
            if (RoundValue <= 0 || RoundValue > 15) RoundValue = 15;
            ObservableCollection<ThreeDimModel> answer = new ObservableCollection<ThreeDimModel> { };

            double pz = oneDimensionalSampleModel.PercentegData.First().P;

            answer.Add(new ThreeDimModel { X = oneDimensionalSampleModel.PercentegData.First().X, P = pz });
            foreach (var el in oneDimensionalSampleModel.PercentegData)
            {
                if (el == oneDimensionalSampleModel.PercentegData.First()) continue;
                else
                {
                    pz += el.P;
                    answer.Add(new ThreeDimModel { X = Math.Round(el.X, RoundValue), P = Math.Round(pz, RoundValue) });
                }
            }
            oneDimensionalSampleModel.HistogramData = answer;
        }
    }
}
