namespace Matrix.Framework.Api.Response
{
    public class ErrorResponse : ResponseBase
    {
        public string Error { get; set; }

        public string StackTrace { get; set; }
    }
}