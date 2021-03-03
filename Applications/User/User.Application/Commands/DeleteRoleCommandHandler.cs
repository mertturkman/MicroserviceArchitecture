using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.RoleAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class DeleteRoleCommandHandler : ICommandHandler<DeleteRoleCommand>
    {
        public readonly IRoleRepository _roleRepository;

        public DeleteRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task ExecuteAsync(DeleteRoleCommand command)
        {
            Role role = await _roleRepository.FindByIdAsync(command.RoleId);

            if(role != null)
            {
                role.Delete();
                _roleRepository.Update(role);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
