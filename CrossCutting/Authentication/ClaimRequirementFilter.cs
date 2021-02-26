using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CrossCutting.Authentication
{
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        public readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            bool isSuperAdmin = context.HttpContext.User.Claims.Any(c => c.Type == CustomClaimType.Role && c.Value == "Super Admin");

            if (!hasClaim && !isSuperAdmin)
            {
                context.Result = new ForbidResult();
            }
        }
    }

}
