using System;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class UpdateRoleCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }   
    }
}