using CrossCutting.Authentication;
using IdentityModel;
using IdentityServer4.Models;

namespace User.Identity.Utility{
    public class ProfileWithClaimResource : IdentityResources.Profile
    {
        public ProfileWithClaimResource()
        {
            this.UserClaims.Add(JwtClaimTypes.Role);
            this.UserClaims.Add(CustomClaimType.Permission);
        }
    }
}