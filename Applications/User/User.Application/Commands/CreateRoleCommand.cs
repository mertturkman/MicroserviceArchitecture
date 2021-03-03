using Newtonsoft.Json;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class CreateRoleCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}