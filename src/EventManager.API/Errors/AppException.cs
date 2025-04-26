using EventManager.API.Common;

namespace EventManager.API.Errors
{
    public class AppException : Exception
    {
        public Error Error { get; }

        public AppException(Error error) : base(error.Description)
        {
            Error = error;
        }
    }
}
