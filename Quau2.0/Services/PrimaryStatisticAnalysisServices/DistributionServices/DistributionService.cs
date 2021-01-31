using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.OneDimensionalModels.BaseModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.DistributionServices.Interfaces;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.DistributionServices
{
    class DistributionService : IDistributionService
    {
        public ObservableCollection<OneDimensionalSampleModel> DensityDistributionBuild(OneDimensionalModel model, int destribution = 0)
        {
            return destribution switch
            {
                0 => DensityNormalDistribution(model),
                1 => DensityExponentialDistribution(model),
                2 => null,
                3 => null,
                4 => null,
                5 => null,
                6 => null,
                7 => null,
                _ => null
            };
        }

        public ObservableCollection<OneDimensionalSampleModel> ProbabilityDistributionBuild(OneDimensionalModel model, int destribution = 0)
        {
            return destribution switch
            {
                0 => ProbabilityNormalDistribution(model),
                1 => ProbabilityExponentialDistribution(model),
                2 => null,
                3 => null,
                4 => null,
                5 => null,
                6 => null,
                7 => null,
                _ => null
            };
        }

        private ObservableCollection<OneDimensionalSampleModel> DensityNormalDistribution(OneDimensionalModel model)
        {
            double m = model.GetParameter("Average");
            double o = model.GetParameter("Dispersion");
            var data = new ObservableCollection<OneDimensionalSampleModel>();
            foreach (var el in model.VariationData)
            {
                double value = 1.0 / (o * Math.Sqrt(2.0 * Math.PI)) * Math.Exp(-Math.Pow(el.X - m, 2.0) / (2.0 * Math.Pow(o, 2.0)));
                data.Add(new OneDimensionalSampleModel{X = el.X, Y = value * model.StepSize});
            }
            return data;
        }
        private ObservableCollection<OneDimensionalSampleModel> ProbabilityNormalDistribution(OneDimensionalModel model)
        {
            double m = model.GetParameter("Average");
            double o = model.GetParameter("Dispersion");
            var data = new ObservableCollection<OneDimensionalSampleModel>();
            foreach (var el in model.VariationData)
            {
                double value = Fs((el.X - m) / o);
                data.Add(new OneDimensionalSampleModel { X = el.X, Y = value });
            }
            return data;
        }

        private double Fs(double u)
        {
            if (u < 0) return 1.0 - Fs(Math.Abs(u));
            double b1 = 0.31938153, b2 = -0.356563782, b3 = 1.781477937, b4 = -1.821255978, b5 = 1.330274429;
            double t = 1.0 / (1.0 + 0.2316419 * u);
            double f = 1.0 - 1.0 / (Math.Sqrt(2.0 * Math.PI)) * Math.Exp(- Math.Pow(u , 2.0) / 2.0) * (b1 * t  + b2 * t * t + b3 * t * t * t + b4 * t * t * t * t + b5 * t * t * t * t * t);

            return f;
        }
        private ObservableCollection<OneDimensionalSampleModel> DensityExponentialDistribution(OneDimensionalModel model)
        {
            double lambda = 1.0 / model.GetParameter("Average");
            var data = new ObservableCollection<OneDimensionalSampleModel>();
            foreach (var el in model.VariationData)
            {
                double value = el.X >= 0 ? lambda * Math.Exp(-lambda * el.X) : 0;
                data.Add(new OneDimensionalSampleModel { X = el.X, Y = value * model.StepSize });
            }
            return data;
        }

        private ObservableCollection<OneDimensionalSampleModel> ProbabilityExponentialDistribution(OneDimensionalModel model)
        {
            double lambda = 1.0 / model.GetParameter("Average");
            var data = new ObservableCollection<OneDimensionalSampleModel>();
            foreach (var el in model.VariationData)
            {
                double value = el.X >= 0 ? 1.0 - Math.Exp(-lambda * el.X) : 0;
                data.Add(new OneDimensionalSampleModel { X = el.X, Y = value  });
            }
            return data;
        }
    }
}
