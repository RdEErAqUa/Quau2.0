﻿using System;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.HistogramSeriesServices.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.ParameterServices.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.PercentageSeriesService.Interfaces;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.VariationSeriesServices.Interfaces;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices
{
    internal class PrimaryStatisticAnalysisService : IPrimaryStatisticAnalysisService
    {
        public PrimaryStatisticAnalysisService(IClassSizeService classSizeService,
            IVariationSeriesService variationSeriesService, IPercentageSeriesService percentageSeriesService,
            IHistogramSeriesService histogramSeriesService,
            IQuantativeCharacteristicSerivce quantativeCharacteristicSerivce)
        {
            this.classSizeService = classSizeService;
            VariationSeriesService = variationSeriesService;
            PercentageSeriesService = percentageSeriesService;
            HistogramSeriesService = histogramSeriesService;
            QuantativeCharacteristicSerivce = quantativeCharacteristicSerivce;
        }

        public IPercentageSeriesService PercentageSeriesService { get; }
        public IHistogramSeriesService HistogramSeriesService { get; }
        public IQuantativeCharacteristicSerivce QuantativeCharacteristicSerivce { get; }
        public IClassSizeService classSizeService { get; }
        public IVariationSeriesService VariationSeriesService { get; }

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
            //
            BuildQuantativeCharachteristics(OneDimData);
        }

        public void BuildQuantativeCharachteristics(OneDimensionalModel OneDimData)
        {
            if (OneDimData == null) return;
            QuantativeCharacteristicSerivce.BuildQuantativeCharacteristic(OneDimData);
        }

        public void ClassSizeSet(OneDimensionalModel OneDimData)
        {
            if (OneDimData == null || OneDimData.ClassSize > 0) return;
            OneDimData.ClassSize =
                (int) Math.Ceiling(classSizeService.SizeClassesFind(OneDimData.OneDimensionalSampleModels));
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