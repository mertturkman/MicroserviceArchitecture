using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.RoleAggregate;
using MediatR;
using User.Application.Abstractions.Command;
using User.Domain.Exceptions;

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
            
            if(role != null)
            {
                role.SetDefinition(command.Name, command.Description);
                _roleRepository.Update(role);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}