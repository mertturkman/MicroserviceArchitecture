using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using User.Application.Abstractions.Command;
using User.Application.Abstractions.Query;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.Exceptions;

namespace User.Application.Commands
{
    public class TokenValidationQueryHandler : IQueryHandler<TokenValidationQuery, object>
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public TokenValidationQueryHandler(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<object> QueryAsync(TokenValidationQuery query)
        {
            Domain.AggregatesModel.UserAggregate.User user = await _userRepository.FindByMailAsync(query.Mail);

            if (user != null)
            {
                int tokenTimeoutMinute = int.Parse(_configuration.GetSection("Params:TokenTimeout").Value);
                bool isTokenValidated = await _userRepository.IsTokenValidationAsync(user.Id, query.Token, tokenTimeoutMinute);

                if (isTokenValidated)
                {
                    return null;
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
