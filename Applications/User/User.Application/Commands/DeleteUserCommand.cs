using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class DeleteUserCommand: ICommand
    {
        public Guid UserId { get; set; } 
    }
}
