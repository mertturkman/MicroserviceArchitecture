using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.PermissionAggregate;
using User.Application.Abstractions.Command;

namespace User.Application.Commands
{
    public class CreatePermissionCommandHandler : ICommandHandler<CreatePermissionCommand>
    {
        private readonly IPermissionRepository _permissionRepository;

        public CreatePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task ExecuteAsync(CreatePermissionCommand command)
        {
            Permission permission = new Permission(command.Name, command.Description, command.Code);
            _permissionRepository.Create(permission);
        }
    }
}
