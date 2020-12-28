using LiveCharts;
using LiveCharts.Wpf;
using Quau2._0.Models.OneDimensionalModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Quau2._0.Services.SeriesServices.OneDimServices.Interfaces
{
    interface IPrimaryAnalysisSeriesService
    {
        StepLineSeries BuildStepLineSeries(ObservableCollection<ThreeDimModel> threeDimModels, Brush BrushSeries = null, int RoundValue = 0);
    }
}
