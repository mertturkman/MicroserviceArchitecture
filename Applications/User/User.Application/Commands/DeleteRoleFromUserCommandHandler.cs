using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class DeleteRoleFromUserCommandHandler : ICommandHandler<DeleteRoleFromUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteRoleFromUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(DeleteRoleFromUserCommand command)
        {
            UserRole userRole = await _userRepository.FindRoleByIdAsync(command.UserRoleId);

            if(userRole != null)
            {
                userRole.Delete();
                _userRepository.UpdateRole(userRole);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
