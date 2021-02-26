using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.PermissionAggregate;
using User.Domain.AggregatesModel.UserAggregate;

namespace User.Application.Commands
{
    public class DeletePermissionCommandHandler : ICommandHandler<DeletePermissionCommand>
    {
        public readonly IPermissionRepository _permissionRepository;

        public DeletePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task ExecuteAsync(DeletePermissionCommand command)
        {
            Permission permission = await _permissionRepository.FindByIdAsync(command.PermissionId);
            permission.Delete();

            _permissionRepository.Update(permission);
        }
    }
}
