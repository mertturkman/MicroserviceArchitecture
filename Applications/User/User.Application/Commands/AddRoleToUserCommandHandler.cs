using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class AddRoleToUserCommandHandler : ICommandHandler<AddRoleToUserCommand>
    {
        public readonly IUserRepository _userRepository;

        public AddRoleToUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(AddRoleToUserCommand command)
        {
            bool isExist = await _userRepository.IsExistRoleByIdAsync(command.UserId, command.RoleId);

            if(!isExist)
            {
                UserRole userRole = new UserRole(command.UserId, command.RoleId);
                _userRepository.AddRole(userRole);
            }
            else
            {
                throw new ConflictException();
            }

        }
    }
}
