using System;
using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.UserAggregate;
using MediatR;
using User.Application.Abstractions.Command;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(UpdateUserCommand command)
        {
            Domain.AggregatesModel.UserAggregate.User user = await _userRepository.FindByIdAsync(command.Id);

            if(user != null)
            {
                user.SetInformation(command.Name, command.Surname, command.Mail, command.Street, command.City, command.State,
                    command.Country, command.ZipCode);
                _userRepository.Update(user);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}