using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.PermissionAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class UpdatePermissionCommandHandler : ICommandHandler<UpdatePermissionCommand>
    {
        private readonly IPermissionRepository _permissionRepository;

        public UpdatePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task ExecuteAsync(UpdatePermissionCommand command)
        {
            Permission permission = await _permissionRepository.FindByIdAsync(command.Id);

            if(permission != null)
            {
                permission.SetDefinition(command.Name, command.Description, command.Code);
                _permissionRepository.Update(permission);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
