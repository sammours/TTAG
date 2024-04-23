namespace TTAG.Domain.Repository
{
    using TTAG.Domain.Model;
    using TTAG.Infrastructure.Azure;

    public class ArtRepository : CosmosDbRepository<Art>, IArtRepository
    {
        public ArtRepository()
            : base("category")
        {
        }
    }
}
