using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace CrossCutting.Authentication
{
    public class PermissionRequirementAttribute : TypeFilterAttribute
    {
        public PermissionRequirementAttribute(string permission) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] { new Claim(CustomClaimType.Permission, permission) };
        }
    }
}
