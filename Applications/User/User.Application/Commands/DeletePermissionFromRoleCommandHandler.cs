using System;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.RoleAggregate;

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
            rolePermission.Delete();

            _roleRepository.UpdatePermission(rolePermission);
        }
    }
}
