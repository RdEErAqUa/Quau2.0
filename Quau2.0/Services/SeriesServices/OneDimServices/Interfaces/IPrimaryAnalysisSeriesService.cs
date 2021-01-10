using System.Collections.ObjectModel;
using System.Windows.Media;
using LiveCharts.Wpf;
using Quau2._0.Models.OneDimensionalModels;

namespace Quau2._0.Services.SeriesServices.OneDimServices.Interfaces
{
    internal interface IPrimaryAnalysisSeriesService
    {
        StepLineSeries BuildStepLineSeries(ObservableCollection<ThreeDimModel> threeDimModels, Brush BrushSeries = null,
            int RoundValue = 0);
    }
}