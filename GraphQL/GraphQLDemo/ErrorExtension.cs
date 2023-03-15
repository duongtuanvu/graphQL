namespace GraphQLDemo
{
    public class ErrorExtension : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.RemovePath().WithMessage(error.Exception.Message);
        }
    }
}
