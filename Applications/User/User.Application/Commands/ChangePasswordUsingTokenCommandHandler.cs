using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using User.Application.Abstractions.Command;
using User.Application.Utility;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class ChangePasswordUsingTokenCommandHandler : ICommandHandler<ChangePasswordUsingTokenCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public ChangePasswordUsingTokenCommandHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task ExecuteAsync(ChangePasswordUsingTokenCommand command)
        {
            Domain.AggregatesModel.UserAggregate.User user = await _userRepository.FindByMailAsync(command.Mail);

            if (user != null)
            {
                int tokenTimeoutMinute = int.Parse(_configuration.GetSection("Params:TokenTimeout").Value);
                bool isTokenValidated = await _userRepository.IsTokenValidationAsync(user.Id, command.Token, tokenTimeoutMinute);

                if(isTokenValidated)
                {
                    UserToken userToken = await _userRepository.FindUserTokenByUserIdAndTokenAsync(user.Id, command.Token);
                    userToken.UseToken();
                    user.ChangePassword(PasswordHasher.CryptoSHA256(command.NewPassword));
                    _userRepository.Update(user);
                }
                else
                {
                    throw new NotFoundException();
                }
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}
