using Quau2._0.Infrastructure.Commands.AsyncLambdaCommands.PrimaryStatisticAnalysisCommands;
using Quau2._0.Models.Base;
using Quau2._0.Models.OneDimensionalModels.BaseModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Models.OneDimensionalModels
{
    class OneDimensionalModel : Model
    {
        /// <summary>
        /// Сервис первичного статистического анализа
        /// </summary>
        private IPrimaryStatisticAnalysisService primaryStatisticAnalysisService;

        #region FileName : String - название файла, в котором хранилась выборка
        private String _FileName;
        /// <summary>
        /// Название файла, в котором хранилась выборка
        /// </summary>
        public String FileName { get => _FileName; set => Set(ref _FileName, value); }
        #endregion

        #region ClassSize : int - размер класса, на которую разбита выборка
        private int _ClassSize;
        /// <summary>
        /// Размер класса, на которую разбита выборка.
        /// При изменении начинает статистический анализ.
        /// </summary>
        public int ClassSize { get => _ClassSize; set { Set(ref _ClassSize, value); StatisticAnalysisRun(); } }
        #endregion

        #region StepSize : double - Размер шага для заданого количества классов
        private double _StepSize;
        /// <summary>
        /// Размер шага для заданого количества классов
        /// </summary>
        public double StepSize { get => _StepSize; set => Set(ref _StepSize, value); }
        #endregion

        #region OneDimensionalSampleModels : ObservableCollection<OneDimensionalSampleModel> - коллекция, которая хранит представление нашей одномерной выборки
        private ObservableCollection<OneDimensionalSampleModel> _OneDimensionalSampleModels;
        /// <summary>
        /// Коллекция, которая хранит представление одномерной выборки
        /// </summary>
        public ObservableCollection<OneDimensionalSampleModel> OneDimensionalSampleModels { get => _OneDimensionalSampleModels; set => Set(ref _OneDimensionalSampleModels, value); }
        #endregion

        #region OneDimensionalSampleModelsSorted : ObservableCollection<OneDimensionalSampleModel> - коллекция, которая хранит представление нашей одномерной выборки в отсортированом порядке по возрастанию
        private ObservableCollection<OneDimensionalSampleModel> _OneDimensionalSampleModelsSorted;
        /// <summary>
        /// Коллекция, которая хранит представление одномерной выборки в отсортированом порядке по возрастанию
        /// </summary>
        public ObservableCollection<OneDimensionalSampleModel> OneDimensionalSampleModelsSorted { get => _OneDimensionalSampleModelsSorted; set => Set(ref _OneDimensionalSampleModelsSorted, value); }
        #endregion

        #region VariationData : ObservableCollection<ThreeDimModel> - коллекция, которая хранит представление о вариационном ряде
        private ObservableCollection<ThreeDimModel> _VariationData;
        /// <summary>
        /// Коллекция, которая хранит представление о вариационном ряде
        /// </summary>
        public ObservableCollection<ThreeDimModel> VariationData { get => _VariationData; set => Set(ref _VariationData, value); }
        #endregion

        #region PercentegData : ObservableCollection<ThreeDimModel> - Функция вероятности(плотности)
        private ObservableCollection<ThreeDimModel> _PercentegData;
        /// <summary>
        /// Функция вероятности(плотности)
        /// </summary>
        public ObservableCollection<ThreeDimModel> PercentegData { get => _PercentegData; set => Set(ref _PercentegData, value); }
        #endregion

        #region HistogramData : ObservableCollection<ThreeDimModel> - Гистограмная оценка
        private ObservableCollection<ThreeDimModel> _HistogramData;

        /// <summary>
        /// Гистограмная оценка
        /// </summary>
        public ObservableCollection<ThreeDimModel> HistogramData { get => _HistogramData; set => Set(ref _HistogramData, value); }
        #endregion

        #region ParameterData : ObservableCollection<OneDimParameter> - коллекция параметров

        private ObservableCollection<OneDimParameter> _ParameterData;
        /// <summary>
        /// Коллекция параметров выборки  
        /// </summary>
        public ObservableCollection<OneDimParameter> ParameterData { get => _ParameterData; set => Set(ref _ParameterData, value); }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void SetAnalysis(IPrimaryStatisticAnalysisService _PrimaryStatisticAnalysisService)
        {
            this.primaryStatisticAnalysisService = _PrimaryStatisticAnalysisService;
        }
        private void StatisticAnalysisRun()
        {
            if (this.primaryStatisticAnalysisService == null) return;
            var analysis = new PrimaryStatisticAnalysisCommand(this.primaryStatisticAnalysisService, this).CommandRun;
            if (analysis.CanExecute("1"))
                analysis.Execute("1");
        }
    }
}
