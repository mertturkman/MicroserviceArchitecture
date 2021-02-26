using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class DeletePermissionCommand: ICommand
    {
        public Guid PermissionId { get; set; }
    }
}
