namespace TTAG.Domain.Profile.Helpers
{
    using System.Security.Claims;
    using TTAG.Domain.Profile.Model;

    public class ProfileHelper : IProfileHelper
    {
        public virtual Profile GetCurrentProfile()
        {
            var identity = ClaimsPrincipal.Current.Identity as ClaimsIdentity;
            return new Profile(identity);
        }

        public bool IsAdmin()
        {
            return true;
        }

        public bool IsAuthorized()
        {
            return true;
        }

        public string GetEmail()
        {
            return this.GetCurrentProfile().Email;
        }
    }
}
