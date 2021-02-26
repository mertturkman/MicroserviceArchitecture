using System;
using User.Application.Abstractions.Query;

namespace User.Application.Queries
{
    public class PermissionFindByIdQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
