using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.HistogramSeriesServices.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices
{
    class PrimaryStatisticAnalysisService : IPrimaryStatisticAnalysisService
    {
        public IClassSizeService classSizeService { get; }
        public IVariationSeriesService VariationSeriesService { get; }
        public IPercentageSeriesService PercentageSeriesService { get; }
        public IHistogramSeriesService HistogramSeriesService { get; }

        public PrimaryStatisticAnalysisService(IClassSizeService classSizeService, IVariationSeriesService variationSeriesService, IPercentageSeriesService percentageSeriesService,
            IHistogramSeriesService histogramSeriesService)
        {
            this.classSizeService = classSizeService;
            this.VariationSeriesService = variationSeriesService;
            this.PercentageSeriesService = percentageSeriesService;
            HistogramSeriesService = histogramSeriesService;
        }
        public void PrimaryAnalysisRun(OneDimensionalModel OneDimData)
        {
            //Установка размеров класса
            ClassSizeSet(OneDimData);
            //Установка вариационого ряда
            BuildPrimaryVariation(OneDimData);
            //Установка графика плотности
            BuildDivisionInClass(OneDimData);
            //Установка гистограмной оценки
            BuildHistogramData(OneDimData);

        }

        public void ClassSizeSet(OneDimensionalModel OneDimData)
        {
            if (OneDimData == null || OneDimData.ClassSize != 0) return;
            OneDimData.ClassSize = (int)Math.Ceiling(classSizeService.SizeClassesFind(OneDimData.OneDimensionalSampleModels));
        }

        public void BuildPrimaryVariation(OneDimensionalModel OneDimData)
        {
            if (OneDimData == null) return;
            VariationSeriesService.BuildVariation(OneDimData);
        }

        public void BuildDivisionInClass(OneDimensionalModel OneDimData)
        {
            if (OneDimData == null) return;
            PercentageSeriesService.DivisionInClass(OneDimData);
        }

        public void BuildHistogramData(OneDimensionalModel OneDimData)
        {
            if (OneDimData == null) return;
            HistogramSeriesService.CreateEmpiricalDataValue(OneDimData);
        }
    }
}
