using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.SeriesServices.OneDimServices.Interfaces;

namespace Quau2._0.Services.SeriesServices.OneDimServices
{
    internal class PrimaryAnalysisSeriesService : IPrimaryAnalysisSeriesService
    {
        public StepLineSeries BuildStepLineSeries(ObservableCollection<ThreeDimModel> threeDimModels,
            Brush BrushSeries = null, int RoundValue = 0)
        {
            if (RoundValue <= 0 || RoundValue > 15) RoundValue = 15;

            var SeriesValues = new ChartValues<ScatterPoint>();

            foreach (var el in threeDimModels)
                SeriesValues.Add(new ScatterPoint(Math.Round(el.X, 5), Math.Round(el.P, 5)));
            return new StepLineSeries {AlternativeStroke = BrushSeries, DataLabels = true, Values = SeriesValues};
        }
    }
}