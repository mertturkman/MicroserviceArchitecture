using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.Exceptions
{
    public class NotFoundException: UserDomainException
    {
        public NotFoundException()
        { }

        public NotFoundException(string message): base(message)
        { }
    }
}
