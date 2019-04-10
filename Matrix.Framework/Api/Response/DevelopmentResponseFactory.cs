using System;

namespace Matrix.Framework.Api.Response
{
    public class DevelopmentResponseFactory : ProductionResponseFactory
    {
        public override IResponse GetErrorResponse(Exception exception)
        {
            var result = base.GetErrorResponse(exception) as ErrorResponse;

            if (result != null)
            {
                result.StackTrace = exception.StackTrace;
            }

            return result;
        }
    }
}