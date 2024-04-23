namespace TTAG.Domain.Model
{
    using TTAG.Common;

    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public byte[] Salt { get; set; }
    }
}
