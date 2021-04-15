using System;
using System.Collections.Generic;
using System.Text;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class ChangePasswordUsingTokenCommand : ICommand
    {
        public string Mail { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
