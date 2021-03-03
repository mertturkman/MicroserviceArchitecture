using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {

        public readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(DeleteUserCommand command)
        {
            Domain.AggregatesModel.UserAggregate.User user = await _userRepository.FindByIdAsync(command.UserId);

            if(user != null)
            {
                user.Delete();
                _userRepository.Update(user);
            } 
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
