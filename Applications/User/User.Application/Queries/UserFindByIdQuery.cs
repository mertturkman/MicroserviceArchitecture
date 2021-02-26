using System;
using User.Application.Abstractions.Query;

namespace User.Application.Queries {
    public class UserFindByIdQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}