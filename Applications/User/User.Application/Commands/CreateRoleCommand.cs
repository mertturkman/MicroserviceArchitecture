using Newtonsoft.Json;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class CreateRoleCommand : ICommand
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        [JsonConstructor]
        public CreateRoleCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }   

    }
}