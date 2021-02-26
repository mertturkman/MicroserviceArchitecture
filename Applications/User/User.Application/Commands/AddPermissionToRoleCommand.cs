using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class AddPermissionToRoleCommand : ICommand
    {
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
    }
}
