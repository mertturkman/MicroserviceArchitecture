using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.RoleAggregate;
using MediatR;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class UpdateRoleCommandHandler : ICommandHandler<UpdateRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task ExecuteAsync(UpdateRoleCommand command)
        {
            Role role = await _roleRepository.FindByIdAsync(command.Id);
            _roleRepository.Update(role);
        }
    }
}