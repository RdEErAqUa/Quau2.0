using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quau2._0.Models.QuantileModels;
using Quau2._0.Services.QuantileServices.Interfaces;
using Quau2._0.Services.WorkDataFile.JsonReaderServices.Interfaces;
using Quau2._0.Services.WorkDataFile.JsonWriteServices.Interfaces;

namespace Quau2._0.Services.QuantileServices
{
    class QuantileService : IQuantileService
    {
        private IJsonWriteService _jsonWrite;
        private IJsonReadService _jsonRead;
        private ICollection<QuantileModel> _quantilies;

        public QuantileService(IJsonReadService jsonRead, IJsonWriteService jsonWrite)
        {
            _jsonRead = jsonRead;
            _jsonWrite = jsonWrite;
        }
        //TODO : Union collection not Concat(basic union didnt work)
        public void ReadValueQuantile(string fileName = null)
        {
            if (_quantilies == null) _quantilies = new List<QuantileModel>();
            ICollection<QuantileModel> data = _jsonRead.Read().ToList();
            _quantilies = _quantilies.Union(data).ToList();
        }
        public void WriteValueQuantile(string fileName = null)
        {
            _jsonWrite.Write(_quantilies, fileName);
        }
        public double getU(double a)
        {
            double c0 = 2.515517, c1 = 0.802853, c2 = 0.010328;
            double d1 = 1.432788, d2 = 0.1892659, d3 = 0.001308;
            double p = a;
            double t = Math.Sqrt(Math.Log(1.0 / Math.Pow(p, 2.0)));
            return t - (c0 + c1 * t + c2 * t * t) / (1.0 + d1 * t + d2 * t * t + d3 * t * t * t);
        }
        public double getT(double a, int v)
        {
            return _quantilies.Where(X => X.Name == "T").Where(X => X.Parameters[0] >= a &&_quantilies.Where(Y => Y.Parameters[0] <= a).ToList().Count != 0
                                          && X.Parameters[1] >= v && _quantilies.Where(Y => Y.Parameters[1] <= v).ToList().Count != 0
                                          ).Select(X => X.Value).FirstOrDefault();
        }
        public double getX(double a, int v)
        {
            return _quantilies.Where(X => X.Name == "X" && X.Parameters == new double[] { a, v }).Select(X => X.Value).FirstOrDefault();
        }
        public double getF(double a, int v1, int v2)
        {
            return _quantilies.Where(X => X.Name == "F" && X.Parameters == new double[] { a, v1, v2 }).Select(X => X.Value).FirstOrDefault();
        }
    }
}
