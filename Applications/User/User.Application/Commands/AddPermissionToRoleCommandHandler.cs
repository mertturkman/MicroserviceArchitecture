using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class AddPermissionToRoleCommandHandler : ICommandHandler<AddPermissionToRoleCommand>
    {
        private readonly IRoleRepository _roleRepository;

        public AddPermissionToRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task ExecuteAsync(AddPermissionToRoleCommand command)
        {

            bool isExist = await _roleRepository.IsExistPermissionByIdAsync(command.RoleId, command.PermissionId);

            if(!isExist)
            {
                RolePermission rolePermission = new RolePermission(command.PermissionId, command.RoleId);
                _roleRepository.AddPermission(rolePermission);
            }
            else
            {
                throw new ConflictException();
            }


        }
    }
}
