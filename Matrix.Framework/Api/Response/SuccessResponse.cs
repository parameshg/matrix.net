namespace Matrix.Framework.Api.Response
{
    public class SuccessResponse<T> : ResponseBase
    {
        public T Data { get; set; }
    }
}