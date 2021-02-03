using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.ParameterServices.Interfaces;
using Quau2._0.Services.QuantileServices.Interfaces;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.ParameterServices
{
    internal class QuantativeCharacteristicSerivce : IQuantativeCharacteristicSerivce
    {
        private IQuantileService _quantileService;

        public QuantativeCharacteristicSerivce(IQuantileService quantileService)
        {
            _quantileService = quantileService;
        }
        public void BuildQuantativeCharacteristic(OneDimensionalModel oneDimensionalModel, double a = 0.95)
        {
            oneDimensionalModel.ParameterData = new ObservableCollection<OneDimParameter>();

            var v1 = oneDimensionalModel.OneDimensionalSampleModels.Count - 1;

            double quantiles = v1 < -60 ? _quantileService.getT(1.0 - a / 2.0, v1) : _quantileService.getU(1.0 - a / 2.0);

            var data = oneDimensionalModel.OneDimensionalSampleModels.Select(X => X.X).ToList();

            var collection = new ObservableCollection<OneDimParameter>();

            //Построить арифметическое
            collection.Add(BuildAverage(oneDimensionalModel, data, quantiles));
            //Дисперсія
            collection.Add(BuildDispersion(oneDimensionalModel,data, quantiles));
            //Дисперсія незсунена
            collection.Add(BuildDispersionUnshifted(oneDimensionalModel, data));
            //Построить контрексцес
            collection.Add(BuildSkewness(oneDimensionalModel, data, quantiles));
            //Построить контрексцес незсунений
            collection.Add(BuildSkewnessUnshifted(oneDimensionalModel, data));
            //Коефіцієнт ексцесу
            collection.Add(BuildKurtosis(oneDimensionalModel, data));
            //Коефіцієнт ексцесу незсунений
            collection.Add(BuildKurtosisUnshifted(oneDimensionalModel, data));
            //Коефіцієнт контр-ексцесу
            collection.Add(BuildCounterKurtosis(oneDimensionalModel, data));
            //Медіана середніх Уолша
            collection.Add(BuildMED(oneDimensionalModel, data));
            //Медіана абсолютних значень
            collection.Add(BuildMAD(oneDimensionalModel, data));
            //Варіація Пірсона
            collection.Add(BuildPearsonVariation(oneDimensionalModel, data));

            oneDimensionalModel.ParameterData = collection;
        }

        public double InitialStaticMoment(ICollection<double> data, int power)
        {
            return data.Average(X => Math.Pow(X, power));
        }

        public double CentralMoment(ICollection<double> data, int power)
        {
            return data.Average(X => Math.Pow(X - InitialStaticMoment(data, 1), power));
        }

        public double Average(ICollection<double> data)
        {
            return data.Average();
        }

        public double Dispersion(ICollection<double> data)
        {
            return Math.Sqrt(CentralMoment(data, 2));
        }

        public double DispersionUnshifted(ICollection<double> data)
        {
            double answerValue = 0;
            double valueInitial = InitialStaticMoment(data, 1);

            for (int i = 0; i < data.Count; i++)
            {
                answerValue += Math.Pow((data.ElementAt(i) - valueInitial), 2);
            }

            answerValue /= data.Count - 1;

            return Math.Sqrt(answerValue);
        }

        public double Skewness(ICollection<double> data)
        {
            return CentralMoment(data, 2);
        }

        public double SkewnessUnShifted(ICollection<double> value)
        {
            return Math.Sqrt(value.Count * (value.Count - 1.0)) / (value.Count - 2.0) * Skewness(value);
        }
        public double Kurtosis(ICollection<double> value)
        {
            return CentralMoment(value, 4) / Math.Pow(CentralMoment(value, 2), 2.0);
        }

        public double KurtosisUnshifted(ICollection<double> value)
        {
            return ((Math.Pow(value.Count, 2.0) - 1.0) / ((value.Count - 2.0) * (value.Count - 3.0)) *
                    ((Kurtosis(value) - 3.0) + 6.0 / (value.Count + 1.0)));
        }
        public double CounterKurtosis(ICollection<double> value)
        {
            return 1.0 / Math.Sqrt(Math.Abs(KurtosisUnshifted(value)));
        }
        public double MAD(ICollection<double> value)
        {
            return (1.483 * MED(value));
        }
        public double MED(ICollection<double> value)
        {
            if (value.Count % 2 == 0)
            {
                int k = value.Count;
                k /= 2;
                double MED = value.ElementAt(k) + value.ElementAt(k + 1);
                MED /= 2;
                return MED;
            }
            else
            {
                int k = value.Count - 1;
                k /= 2;
                double MED = value.ElementAt(k + 1);
                return MED;
            }
        }
        public double PearsonVariation(ICollection<double> value)
        {
            return Dispersion(value) / Average(value);
        }

        private double RouteMeanSquareAverage(ICollection<double> value)
        {
            return DispersionUnshifted(value) / Math.Sqrt(value.Count);
        }

        private OneDimParameter BuildAverage(OneDimensionalModel oneDimensionalModel, List<double> data,double quantile)
        {
            var average = Average(data);
            var routeMenaSquareAverage =
                RouteMeanSquareAverage(data);
            var parameter = new OneDimParameter
            {
                Name = "Average",
                Value = average,
                RootMeanSquareValue = routeMenaSquareAverage,
                MaxValue = average + quantile * routeMenaSquareAverage,
                MinValue = average - quantile * routeMenaSquareAverage
            };

            return parameter;
        }
        private double RouteMeanSquareDispersion(ICollection<double> value)
        {
            return DispersionUnshifted(value) / Math.Sqrt(2.0 * value.Count);
        }
        private OneDimParameter BuildDispersion(OneDimensionalModel oneDimensionalModel, List<double> data, double quantile)
        {
            var dispersion = Dispersion(data);
            var routeMeanSquareDispersion = RouteMeanSquareDispersion(data);
            var parameter = new OneDimParameter
            {
                Name = "Dispersion",
                Value =
                dispersion,
                RootMeanSquareValue = routeMeanSquareDispersion,
                MaxValue = dispersion + quantile * routeMeanSquareDispersion,
                MinValue = dispersion - quantile * routeMeanSquareDispersion

            };

            return parameter;
        }

        private OneDimParameter BuildDispersionUnshifted(OneDimensionalModel oneDimensionalModel, List<double> data)
        {
            var parameter = new OneDimParameter
            {
                Name = "DispersionUnshifted",
                Value =
                    DispersionUnshifted(data)
            };

            return parameter;
        }
        private double RouteMeanSquareSkewness(ICollection<double> value)
        {
            return Math.Sqrt(6.0 / (double)value.Count * (1.0 - 12.0 / (2.0 * value.Count + 7)));
        }
        private OneDimParameter BuildSkewness(OneDimensionalModel oneDimensionalModel, List<double> data, double quantile)
        {
            var skewness = Skewness(data);
            var routeMeanSquareSkewness = RouteMeanSquareSkewness(data);
            var parameter = new OneDimParameter
            {
                Name = "Skewness",
                Value = skewness,
                RootMeanSquareValue = routeMeanSquareSkewness,
                MaxValue = skewness + quantile * routeMeanSquareSkewness,
                MinValue = skewness - quantile * routeMeanSquareSkewness
            };

            return parameter;
        }

        private OneDimParameter BuildSkewnessUnshifted(OneDimensionalModel oneDimensionalModel, List<double> data)
        {
            var parameter = new OneDimParameter
            {
                Name = "SkewnessUnshifted",
                Value =
                SkewnessUnShifted(data)
            };

            return parameter;
        }

        private OneDimParameter BuildKurtosis(OneDimensionalModel oneDimensionalModel, List<double> data)
        {
            var parameter = new OneDimParameter
            {
                Name = "Kurtosis",
                Value = Kurtosis(data)
            };

            return parameter;
        }

        private OneDimParameter BuildKurtosisUnshifted(OneDimensionalModel oneDimensionalModel, List<double> data)
        {
            var parameter = new OneDimParameter
            {
                Name = "KurtosisUnshifted",
                Value = KurtosisUnshifted(data)
            };
            return parameter;
        }

        private OneDimParameter BuildCounterKurtosis(OneDimensionalModel oneDimensionalModel, List<double> data)
        {
            var parameter = new OneDimParameter
            {
                Name = "CounterKurtosis",
                Value = CounterKurtosis(data)
            };
            return parameter;
        }

        private OneDimParameter BuildMAD(OneDimensionalModel oneDimensionalModel, List<double> data)
        {
            var parameter = new OneDimParameter
            {
                Name = "MAD",
                Value = MAD(data)
            };

            return parameter;
        }
        private OneDimParameter BuildMED(OneDimensionalModel oneDimensionalModel, List<double> data)
        {
            var parameter = new OneDimParameter
            {
                Name = "MED",
                Value = MED(data)
            };

            return parameter;
        }

        private OneDimParameter BuildPearsonVariation(OneDimensionalModel oneDimensionalModel, List<double> data)
        {
            var parameter = new OneDimParameter
            {
                Name = "PearsonVariation",
                Value = PearsonVariation(data)
            };

            return parameter;
        }

        //Дополнительные вычисления
        public double ourB_Find(ICollection<double> ourNum, int count)
        {
            if (count % 2 == 0)
            {
                int k = count / 2;

                double middleMomentum2k2 = CentralMoment(ourNum, 2 * k + 2);
                double middleMomentum2 = CentralMoment(ourNum, 2);

                double ourAnswer = middleMomentum2k2 / (Math.Pow(middleMomentum2, k + 1.0));

                return ourAnswer;
            }
            else
            {
                int k = (count - 1) / 2;
                double middleMomentum2k3 = CentralMoment(ourNum, 2 * k + 3);
                double middleMomentum2 = CentralMoment(ourNum, 2);
                double middleMomentum3 = CentralMoment(ourNum, 3);

                double ourAnswer = (middleMomentum3 * middleMomentum2k3) / (Math.Pow(middleMomentum2, k + 3.0));

                return ourAnswer;
            }
        }
    }
}