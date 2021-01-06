using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.ParameterServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.ParameterServices
{
    class QuantativeCharacteristicSerivce : IQuantativeCharacteristicSerivce
    {
        public void BuildQuantativeCharacteristic(OneDimensionalModel oneDimensionalModel)
        {
            oneDimensionalModel.ParameterData = new System.Collections.ObjectModel.ObservableCollection<OneDimParameter>();

            //Построить арифметическое
            BuildAverage(oneDimensionalModel);
            //Построить среднее арифметическое
            BuildSquareAverage(oneDimensionalModel);
            //Построить контрексцес
            BuildSkewness(oneDimensionalModel);
        }
        //Main function
        public double InitialStaticMoment(IEnumerable<double> data, int power) =>
            data.Average(X => Math.Pow(X, power));
        public double CentralMoment(IEnumerable<double> data, int power) =>
            data.Average(X => Math.Pow(X - InitialStaticMoment(data, 1), power));
        //
        //Rest function(Minor)
        public double Average(IEnumerable<double> data) =>
            data.Average();
        public double SquareAverage(IEnumerable<double> data) =>
            Math.Sqrt(CentralMoment(data, 2));
        public double Skewness(IEnumerable<double> data) =>
            CentralMoment(data, 2);
        //

        private void BuildAverage(OneDimensionalModel oneDimensionalModel)
        {
            var Parameter = new OneDimParameter();
            //СреднееАрифметическое
            Parameter.ParamName = "Average";
            Parameter.ParamValue = Average(oneDimensionalModel.OneDimensionalSampleModels.Select(X => X.X));

            oneDimensionalModel.ParameterData.Add(Parameter);
        }
        private void BuildSquareAverage(OneDimensionalModel oneDimensionalModel)
        {
            var Parameter = new OneDimParameter();

            Parameter.ParamName = "SquareAverage";
            Parameter.ParamValue = SquareAverage(oneDimensionalModel.OneDimensionalSampleModels.Select(X => X.X));

            oneDimensionalModel.ParameterData.Add(Parameter);
        }

        private void BuildSkewness(OneDimensionalModel oneDimensionalModel)
        {
            var Parameter = new OneDimParameter();

            Parameter.ParamName = "Skewness";
            Parameter.ParamValue = Skewness(oneDimensionalModel.OneDimensionalSampleModels.Select(X => X.X));

            oneDimensionalModel.ParameterData.Add(Parameter);
        }
    }
}
