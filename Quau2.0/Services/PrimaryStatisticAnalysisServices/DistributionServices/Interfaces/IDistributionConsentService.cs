using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.OneDimensionalModels;
using Quau2._0.Models.ParameterEstimateModels;

namespace Quau2._0.Services.PrimaryStatisticAnalysisServices.DistributionServices.Interfaces
{
    interface IDistributionConsentService
    {
        ParameterEstimate KolmogorovTest(OneDimensionalModel model);

        ParameterEstimate PearsonTest(OneDimensionalModel model);
    }
}
