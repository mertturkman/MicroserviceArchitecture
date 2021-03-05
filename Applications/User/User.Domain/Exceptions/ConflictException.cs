using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace User.Domain.Exceptions
{
    public class ConflictException : UserDomainException
    {
        public ConflictException(): base(HttpStatusCode.Conflict)
        { }

        public ConflictException(int code) : base(HttpStatusCode.Conflict, code)
        { }

        public ConflictException(string message) : base(HttpStatusCode.Conflict, message)
        { }

        public ConflictException(int code, string message) : base(HttpStatusCode.Conflict, code, message)
        { }
    }
}
