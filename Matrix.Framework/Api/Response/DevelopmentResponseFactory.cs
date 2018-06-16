using System;

namespace Matrix.Framework.Api.Response
{
    public class DevelopmentResponseFactory : ProductionResponseFactory
    {
        protected override ErrorResponse GetErrorResponse(Exception exception)
        {
            var result = base.GetErrorResponse(exception);

            result.StackTrace = exception.StackTrace;

            return result;
        }
    }
}