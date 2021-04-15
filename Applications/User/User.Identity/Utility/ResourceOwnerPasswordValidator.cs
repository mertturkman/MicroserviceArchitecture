using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using static IdentityModel.OidcConstants;
using User.Infrastructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using IdentityModel;
using CrossCutting.Authentication;
using Microsoft.Extensions.Configuration;
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.AggregatesModel.RoleAggregate;

namespace User.Identity.Utility
{
    public class ResourceOwnerPasswordValidator: IResourceOwnerPasswordValidator
    {
        private readonly UserContext _userContext;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public ResourceOwnerPasswordValidator(UserContext userContext, IUserRepository userRepository, IConfiguration configuration) {
            _userContext = userContext;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public virtual async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            Domain.AggregatesModel.UserAggregate.User user = await _userContext.Users
                .Include(user => user.UserRoles)
                    .ThenInclude(userRole => userRole.Role)
                        .ThenInclude(role => role.RolePermissions)
                            .ThenInclude(rolePermission => rolePermission.Permission)
                .FirstOrDefaultAsync(user => 
                    user.Username == context.UserName)
                .ConfigureAwait(false);

            if (user != null) 
            {
                int failedLoginAttemptTimeout = int.Parse(_configuration.GetSection("Params:FailedLoginAttemptTimeout").Value);
                int failedLoginAttemptLimit = int.Parse(_configuration.GetSection("Params:FailedLoginAttemptLimit").Value);

                if (user.IsLoginBlocked(failedLoginAttemptTimeout, failedLoginAttemptLimit))
                {
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest,"USER_BLOCKED");
                }
                else if (user.Password == PasswordHasher.CryptoSHA256(context.Password))
                {
                    List<Claim> claims = new List<Claim>();

                    foreach (UserRole userRole in user.UserRoles)
                    {
                        claims.Add(new Claim(CustomClaimType.Role, userRole.Role.Name));
                        foreach(RolePermission rolePermission in userRole.Role.RolePermissions)
                            claims.Add(new Claim(CustomClaimType.Permission, rolePermission.Permission.Name));
                    }
                    
                    user.SuccessLoginAttempt();
                    _userRepository.Update(user);
                    await _userContext.SaveChangesAsync().ConfigureAwait(false);
                    
                    context.Result = new GrantValidationResult(user.Id.ToString(), AuthenticationMethods.Password, claims);      
                }
                else
                {
                    user.FailedLoginAttempt(failedLoginAttemptLimit);
                    _userRepository.Update(user);
                    await _userContext.SaveChangesAsync().ConfigureAwait(false);
                    
                    context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "WRONG_PASSWORD");
                }
            }
            else {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "USER_NOTFOUND");
            }
        }
    }
}