using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.PermissionAggregate;
using User.Domain.AggregatesModel.RoleAggregate;

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
            RolePermission rolePermission = new RolePermission(command.PermissionId, command.RoleId);
            _roleRepository.AddPermission(rolePermission);
        }
    }
}
