namespace TTAG.Domain.Profile.Model
{
    using System.Linq;
    using System.Security.Claims;

    public class Profile
    {
        public Profile()
        {
            this.IsBlocked = false;
        }

        public Profile(ClaimsIdentity identity)
        {
            this.FirstName = identity.Claims.FirstOrDefault(c => c.Type.Contains("FirstName"))?.Value;
            this.LastName = identity.Claims.FirstOrDefault(c => c.Type.Contains("LastName"))?.Value;
            this.Email = identity.Claims.FirstOrDefault(c => c.Type.Contains("Email"))?.Value;
            this.UserName = identity.Claims.FirstOrDefault(c => c.Type.Contains("UserName"))?.Value;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public bool IsBlocked { get; set; }
    }
}
