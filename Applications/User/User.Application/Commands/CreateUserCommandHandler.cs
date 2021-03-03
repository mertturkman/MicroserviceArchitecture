using System;
using System.Threading;
using System.Threading.Tasks;
using User.Domain.AggregatesModel.UserAggregate;
using MediatR;
using User.Application.Abstractions.Command;
using User.Domain.Exceptions;

namespace User.Application.Commands {
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand> 
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(CreateUserCommand command)
        {
            bool isExist = await _userRepository.IsExistByUsernameAndMailAsync(command.Username, command.Mail);

            if(!isExist)
            {
                Address address = new Address(command.Street, command.City, command.State, command.Country, command.ZipCode);
                Domain.AggregatesModel.UserAggregate.User user = new Domain.AggregatesModel.UserAggregate.User(command.Name,
                    command.Surname, command.Username, command.Password, command.Mail, address);

                _userRepository.Create(user);
            } 
            else
            {
                throw new ConflictException();
            }
        }
    }
}