using System.Threading.Tasks;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Application.Abstractions.Command;
using User.Domain.Exceptions;

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
            bool isExist = await _roleRepository.IsExistByNameAsync(command.Name);

            if(!isExist)
            {
                Role role = new Role(command.Name, command.Description);
                _roleRepository.Create(role);
            }
            else
            {
                throw new ConflictException();
            }
        }
    }
}