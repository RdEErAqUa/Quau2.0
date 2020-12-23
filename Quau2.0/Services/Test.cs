using Quau2._0.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Services
{
    class Test : ITest
    {
        public String WriteMessage(string message)
        {
            return "hello";
        }
    }
}
