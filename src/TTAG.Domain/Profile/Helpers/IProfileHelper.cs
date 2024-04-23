namespace TTAG.Domain.Profile.Helpers
{
    using Profile.Model;

    public interface IProfileHelper
    {
        Profile GetCurrentProfile();

        bool IsAuthorized();

        bool IsAdmin();

        string GetEmail();
    }
}
