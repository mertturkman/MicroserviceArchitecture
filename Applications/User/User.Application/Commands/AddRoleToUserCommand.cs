using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class AddRoleToUserCommand: ICommand
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
