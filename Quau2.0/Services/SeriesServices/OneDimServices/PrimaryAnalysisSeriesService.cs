using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using OxyPlot;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.OneDimensionalModels.BaseModels;
using Quau2._0.Services.SeriesServices.OneDimServices.Interfaces;

namespace Quau2._0.Services.SeriesServices.OneDimServices
{
    internal class PrimaryAnalysisSeriesService : IPrimaryAnalysisSeriesService
    {
        public StepLineSeries BuildStepLineSeries(ObservableCollection<ThreeDimModel> threeDimModels, int RoundValue = 0,
            Brush BrushSeries = null)
        {
            if (RoundValue <= 0 || RoundValue > 15) RoundValue = 15;

            var SeriesValues = new ChartValues<ScatterPoint>();

            foreach (var el in threeDimModels)
                SeriesValues.Add(new ScatterPoint(Math.Round(el.X, 5), Math.Round(el.P, 5)));
            return new StepLineSeries {AlternativeStroke = BrushSeries, DataLabels = true, Values = SeriesValues};
        }

        public LineSeries BuildLine(ObservableCollection<OneDimensionalSampleModel> threeDimModels, int RoundValue = 0)
        {
            if (RoundValue <= 0 || RoundValue > 15) RoundValue = 15;

            var SeriesValues = new ChartValues<ScatterPoint>();

            foreach (var el in threeDimModels)
                SeriesValues.Add(new ScatterPoint(Math.Round(el.X, 5), Math.Round(el.Y, 5)));
            return new LineSeries() { DataLabels = true, Values = SeriesValues };
        }

        public OxyPlot.Series.Series BuildStepLineSeriesOxy(ObservableCollection<ThreeDimModel> threeDimModels, int RoundValue = 0, bool vericalLine = true)
        {
            if (RoundValue <= 0 || RoundValue > 15) RoundValue = 15;

            var SeriesValues = new OxyPlot.Series.StairStepSeries();
            var tempData = new ObservableCollection<OneDimensionalSampleModel>();
            foreach (var el in threeDimModels)
                tempData.Add(new OneDimensionalSampleModel { X = el.X, Y = el.P});
            SeriesValues.DataFieldX = "X";
            SeriesValues.DataFieldY = "Y";
            SeriesValues.VerticalStrokeThickness = vericalLine ? SeriesValues.VerticalStrokeThickness : 0;
            SeriesValues.ItemsSource = tempData;
            return SeriesValues;
        }

        public OxyPlot.Series.Series BuildLineOxy(ObservableCollection<OneDimensionalSampleModel> threeDimModels, int RoundValue = 0)
        {
            if (RoundValue <= 0 || RoundValue > 15) RoundValue = 15;

            var SeriesValues = new OxyPlot.Series.LineSeries();
            var tempData = new ObservableCollection<OneDimensionalSampleModel>();
            foreach (var el in threeDimModels)
                tempData.Add(new OneDimensionalSampleModel { X = el.X, Y = el.Y });
            SeriesValues.DataFieldX = "X";
            SeriesValues.DataFieldY = "Y";
            SeriesValues.ItemsSource = tempData;
            return SeriesValues;
        }
    }
}