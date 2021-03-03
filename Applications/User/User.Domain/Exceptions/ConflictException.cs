using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.Exceptions
{
    public class ConflictException : UserDomainException
    {
        public ConflictException()
        { }

        public ConflictException(string message) : base(message)
        { }
    }
}
