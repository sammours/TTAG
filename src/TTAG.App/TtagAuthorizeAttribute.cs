namespace TTAG.App
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc.Filters;

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class TtagAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public TtagAuthorizeAttribute()
        {
        }

        public string RequiredRoles { get; set; }

        public bool FillClaimsOnly { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //var identity = ClaimsPrincipal.Current.Identity as ClaimsIdentity;

            // var profile = profileRepository.GetById(id) as Profile;
            //if (profile == null || profile.isblocked)
            //{
            //    return false;
            //}

            //    identity.AddClaim(new Claim("FirstName", profile.FirstName ?? string.Empty, ClaimValueTypes.String));
            //    identity.AddClaim(new Claim("LastName", LastName ?? string.Empty, ClaimValueTypes.String));
            //    identity.AddClaim(new Claim("Email", profile.Email ?? string.Empty, ClaimValueTypes.String));
            //    identity.AddClaim(new Claim("UserName", profile.UserName ?? string.Empty, ClaimValueTypes.String));
        }
    }
}
