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
using User.Domain.AggregatesModel.UserAggregate;
using User.Domain.AggregatesModel.RoleAggregate;

namespace User.Identity.Utility
{
    public class ResourceOwnerPasswordValidator: IResourceOwnerPasswordValidator
    {
        private readonly UserContext _userContext;

        public ResourceOwnerPasswordValidator(UserContext userContext) {
            _userContext = userContext;
        }

        public virtual async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            string clientId = context.Request?.Client?.ClientId;

            string hash = PasswordHasher.CryptoSHA256(context.Password);

            var user = await _userContext.Users
                .Include(user => user.UserRoles)
                    .ThenInclude(userRole => userRole.Role)
                        .ThenInclude(role => role.RolePermissions)
                            .ThenInclude(rolePermission => rolePermission.Permission)
                .FirstOrDefaultAsync(user => 
                    user.Username == context.UserName && 
                    user.Password == PasswordHasher.CryptoSHA256(context.Password))
                .ConfigureAwait(false);
 
            if (user != null) {

                List<Claim> claims = new List<Claim>();

                foreach (UserRole userRole in user.UserRoles)
                {
                    claims.Add(new Claim(CustomClaimType.Role, userRole.Role.Name));
                    foreach(RolePermission rolePermission in userRole.Role.RolePermissions)
                        claims.Add(new Claim(CustomClaimType.Permission, rolePermission.Permission.Name));
                }

                context.Result = new GrantValidationResult(user.Id.ToString(), AuthenticationMethods.Password, claims);               
            }
            else {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
            }
        }
    }
}