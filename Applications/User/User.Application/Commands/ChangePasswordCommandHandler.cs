using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Application.Abstractions.Command;
using User.Application.Utility;
using User.Domain.AggregatesModel.UserAggregate;

namespace User.Application.Commands
{
    public class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {

        public readonly IUserRepository _userRepository;

        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ExecuteAsync(ChangePasswordCommand command)
        {
            Domain.AggregatesModel.UserAggregate.User user = await _userRepository.FindByIdAsync(command.UserId);
            user.ChangePassword(PasswordHasher.CryptoSHA256(command.NewPassword));
        }
    }
}
