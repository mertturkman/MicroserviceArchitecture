using System;
using User.Application.Abstractions.Query;

namespace User.Application.Queries
{
    public class RoleFindByIdQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}