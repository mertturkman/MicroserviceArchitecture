using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace User.Domain.Exceptions
{
    public class BadRequestException: UserDomainException
    {
        public BadRequestException(): base(HttpStatusCode.BadRequest)
        { }

        public BadRequestException(int code): base(HttpStatusCode.BadRequest, code)
        { }

        public BadRequestException(int code, string message): base(HttpStatusCode.BadRequest, code, message)
        { }

        public BadRequestException(object errorObject) : base(HttpStatusCode.BadRequest, errorObject)
        { }
    }
}
