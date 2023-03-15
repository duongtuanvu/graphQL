namespace GraphQLDemo
{
    public class ResponseMessage
    {
        public ResponseMessage(int httpStatusCode = 200, string? message = "", object? data = null)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
            Data = data;
        }

        public int HttpStatusCode { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
}
