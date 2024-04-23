namespace TTAG.Domain.Service
{
    using System.Threading.Tasks;
    using Model;

    public interface IUserService
    {
        Task<User> AddOrUpdateAsync(User user);

        string Login(string username, string password);
    }
}
