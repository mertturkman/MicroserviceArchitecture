using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class DeletePermissionFromRoleCommand: ICommand
    {
        public Guid RolePermissionId { get; set; }
    }
}
