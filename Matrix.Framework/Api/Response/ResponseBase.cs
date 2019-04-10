using System;

namespace Matrix.Framework.Api.Response
{
    public class ResponseBase : IResponse
    {
        public DateTime Timestamp { get; set; }

        public string Agent { get; set; }

        public bool Status { get; set; }

        public int Code { get; set; }

        public ResponseBase()
        {
            Timestamp = DateTime.Now;
            Status = false;
            Code = 0;
        }
    }
}