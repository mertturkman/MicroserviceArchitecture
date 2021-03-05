using Middleware;
using System;
using System.Net;

namespace User.Domain.Exceptions
{
    public class UserDomainException : GlobalException
    {
        public UserDomainException(HttpStatusCode statusCode) : base(statusCode)
        { }

        public UserDomainException(HttpStatusCode statusCode, int code): base(statusCode, code)
        { }

        public UserDomainException(HttpStatusCode statusCode, string message): base(statusCode, message)
        { }

        public UserDomainException(HttpStatusCode statusCode, int code, string message) : base(statusCode, code, message)
        { }

        public UserDomainException(HttpStatusCode statusCode, string message, Exception innerException): base(statusCode, message, innerException)
        { }

        public UserDomainException(HttpStatusCode statusCode, int code, string message, Exception innerException) : base(statusCode, code, message, innerException)
        { }

        public UserDomainException(HttpStatusCode statusCode, object errorObject) : base(statusCode, errorObject)
        { }
    }
}