using System.Net;

namespace RestAPI.Common.CustomExceptions
{
    public class NotFoudException: WebException
    {
        public int StatusCode { get; }
        public NotFoudException(string message, int statusCode): base(message)
        {
            StatusCode = statusCode;
        }
    }
}
