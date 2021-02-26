using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Query;

namespace User.Application.Queries
{
    public class RoleListFindByUserIdQuery: IQuery
    {
        public Guid UserId { get; set; }
    }
}
