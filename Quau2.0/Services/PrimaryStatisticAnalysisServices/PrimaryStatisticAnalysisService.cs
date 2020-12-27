using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Services.PrimaryStatisticAnalysisServices.Interfaces;
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

        public PrimaryStatisticAnalysisService(IClassSizeService classSizeService)
        {
            this.classSizeService = classSizeService;
        }
        public void PrimaryAnalysisRun(OneDimensionalModel OneDimData)
        {
            //Установка размеров класса
            ClassSizeSet(OneDimData);
            //Установка шага
        }

        public void ClassSizeSet(OneDimensionalModel OneDimData)
        {
            if (OneDimData == null) return;
            OneDimData.ClassSize = (int)Math.Ceiling(classSizeService.SizeClassesFind(OneDimData.OneDimensionalSampleModels));
        }
    }
}
