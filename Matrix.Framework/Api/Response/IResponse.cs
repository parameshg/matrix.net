using System;

namespace Matrix.Framework.Api.Response
{
    public interface IResponse
    {
        DateTime Timestamp { get; set; }

        string Agent { get; set; }

        bool Status { get; set; }

        int Code { get; set; }
    }
}