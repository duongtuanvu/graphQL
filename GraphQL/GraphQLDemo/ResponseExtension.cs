namespace GraphQLDemo
{
    public class ResponseExtension
    {
        public static ResponseMessage ToResponse<T>(int httpStatusCode = 200, string message = "", T? data = default) where T : class
        {
            return new ResponseMessage()
            {
                HttpStatusCode = httpStatusCode,
                Message = message,
                Data = data
            };
        }
    }
}
