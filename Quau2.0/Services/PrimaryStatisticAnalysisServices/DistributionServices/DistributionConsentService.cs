using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.ParameterEstimateModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.DistributionServices.Interfaces;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.DistributionServices
{
    class DistributionConsentService : IDistributionConsentService
    {
        public ParameterEstimate KolmogorovTest(OneDimensionalModel model)
        {
            var data = new ParameterEstimate();

            double a = model.OneDimensionalSampleModels.Count < 30 ? 0.3 : model.OneDimensionalSampleModels.Count < 100 ? 0.1 :
                    model.OneDimensionalSampleModels.Count < 200 ? 0.05 : 0.01;

            data.Name = "Kolmogorov";
            data.Value = Kolmogorov(model);
            data.ProbabilityP = a;
            data.Significance = a < data.Value ? false : true;
            return data;
        }

        public ParameterEstimate PearsonTest(OneDimensionalModel model)
        {
            var data = new ParameterEstimate();

            data.Name = "Pearson";
            data.Value = Pearson(model);
            return data;
        }

        private double Pearson(OneDimensionalModel model)
        {
            double Xi2 = 0;
            double ni = 0;
            double ni0 = 0;
            for (int i = 1; i < model.ClassSize; i++)
            {
                double closestLeft = model.Distribution.DataProbability.Aggregate((x, y) => Math.Abs(x.X - model.VariationData[i - 1].X) < Math.Abs(y.X - model.VariationData[i - 1].X) ? x : y).Y;
                double closestRight = model.Distribution.DataProbability.Aggregate((x, y) => Math.Abs(x.X - model.VariationData[i].X) < Math.Abs(y.X - model.VariationData[i].X) ? x : y).Y;
                double pi = closestRight - closestLeft;

                ni0 = pi * model.OneDimensionalSampleModels.Count;
                Xi2 += Math.Pow(model.VariationData[i].N - ni0, 2.0) / ni0;
            }
            return Xi2;
        }

        private double Kolmogorov(OneDimensionalModel model)
        {
            List<double> f1 = new List<double>();

            var empiricalData = model.VariationData.Select(X => model.VariationData.Where(Y => Y.X <= X.X).Sum(Y => Y.P)).ToList();

            for (int i = 0; i < model.Distribution.DataProbability.Count; i++)
            {
                double f2 = model.Distribution.DataProbability[i].Y - empiricalData[i];
                f1.Add(Math.Abs(f2));
            }

            double fmax = f1.Max();
            double z = Math.Sqrt(model.VariationData.Count) * fmax;

            double KolmogorovValueLoop = 0;

            for (double i = 1; i < 30000; i++)
            {
                KolmogorovValueLoop += (Math.Pow(-1.0, i) * Math.Exp(-2.0 * Math.Pow(i, 2.0) * Math.Pow(z, 2.0)));
            }
            KolmogorovValueLoop = 1 + 2 * KolmogorovValueLoop;

            return KolmogorovValueLoop;
        }
    }
}
