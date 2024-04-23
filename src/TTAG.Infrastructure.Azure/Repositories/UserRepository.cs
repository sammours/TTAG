namespace TTAG.Domain.Repository
{
    using TTAG.Domain.Model;
    using TTAG.Infrastructure.Azure;

    public class UserRepository : CosmosDbRepository<User>, IUserRepository
    {
        public UserRepository()
            : base("email")
        {
        }
    }
}
