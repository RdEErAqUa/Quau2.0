using System;

namespace Quau2._0.Infrastructure.Async
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}