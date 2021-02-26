using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class ChangePasswordCommand: ICommand
    {
        public Guid UserId { get; set; }
        public string NewPassword { get; set; }
    }
}
