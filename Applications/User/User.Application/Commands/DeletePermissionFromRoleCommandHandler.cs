using System;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class DeletePermissionFromRoleCommandHandler : ICommandHandler<DeletePermissionFromRoleCommand>
    {

        private readonly IRoleRepository _roleRepository;

        public DeletePermissionFromRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task ExecuteAsync(DeletePermissionFromRoleCommand command)
        {
            RolePermission rolePermission = await _roleRepository.FindPermissionByIdAsync(command.RolePermissionId);

            if(rolePermission != null)
            {
                rolePermission.Delete();
                _roleRepository.UpdatePermission(rolePermission);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
