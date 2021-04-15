using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class ForgetPasswordCommandHandler : ICommandHandler<ForgetPasswordCommand>
    {
        private readonly IUserRepository _userRepository;

        public ForgetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(ForgetPasswordCommand command)
        {
            Domain.AggregatesModel.UserAggregate.User user = await _userRepository.FindByMailAsync(command.Mail);

            if(user != null)
            {
                UserToken userToken = new UserToken(user.Id, user.Mail);
                _userRepository.CreateToken(userToken);
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
