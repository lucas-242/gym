using System.Net;

namespace Gym.Exceptions
{
    public class AppException: Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ContentType { get; set; } = @"application/json";

        public AppException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public AppException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public AppException(HttpStatusCode statusCode, Exception inner)
            : this(statusCode, inner.ToString()) { }
    }
}
