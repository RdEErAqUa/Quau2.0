using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quau2._0.Infrastructure.Async
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }

}
