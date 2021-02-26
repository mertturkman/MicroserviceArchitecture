using System;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class DeleteRoleCommand: ICommand
    {
        public Guid RoleId { get; set; }
    }
}