using System;

namespace Branch.Domain.Exceptions
{
    public class BranchDomainException : Exception
    {
        public BranchDomainException()
        { }

        public BranchDomainException(string message)
            : base(message)
        { }

        public BranchDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}