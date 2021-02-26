using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class DeleteRoleFromUserCommand: ICommand
    {
        public Guid UserRoleId { get; set; }
    }
}
