using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace User.Domain.Exceptions
{
    public class NotFoundException: UserDomainException
    {
        public NotFoundException(): base(HttpStatusCode.NotFound)
        { }

        public NotFoundException(int code) : base(HttpStatusCode.NotFound, code)
        { }

        public NotFoundException(string message): base(HttpStatusCode.NotFound, message)
        { }

        public NotFoundException(int code, string message) : base(HttpStatusCode.NotFound, code, message)
        { }
    }
}
