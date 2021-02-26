using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.RoleAggregate;
using MediatR;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task ExecuteAsync(CreateRoleCommand command)
        {
            Role role = new Role(command.Name, command.Description);
            _roleRepository.Create(role);
        }
    }
}