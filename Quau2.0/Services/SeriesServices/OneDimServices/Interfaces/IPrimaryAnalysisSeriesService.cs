using System.Collections.ObjectModel;
using System.Windows.Media;
using LiveCharts.Wpf;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.OneDimensionalModels.BaseModels;

namespace Quau2._0.Services.SeriesServices.OneDimServices.Interfaces
{
    internal interface IPrimaryAnalysisSeriesService
    {
        StepLineSeries BuildStepLineSeries(ObservableCollection<ThreeDimModel> threeDimModels, int RoundValue = 0,
            Brush BrushSeries = null);

        LineSeries BuildLine(ObservableCollection<OneDimensionalSampleModel> threeDimModels, int RoundValue = 0);

        OxyPlot.Series.Series BuildStepLineSeriesOxy(ObservableCollection<ThreeDimModel> threeDimModels, int RoundValue = 0, bool vericalLine = true);

        OxyPlot.Series.Series BuildLineOxy(ObservableCollection<OneDimensionalSampleModel> threeDimModels,
            int RoundValue = 0);
    }
}