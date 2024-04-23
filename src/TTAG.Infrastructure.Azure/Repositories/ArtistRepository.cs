namespace TTAG.Domain.Repository
{
    using TTAG.Domain.Model;
    using TTAG.Infrastructure.Azure;

    public class ArtistRepository : CosmosDbRepository<Artist>, IArtistRepository
    {
        public ArtistRepository()
            : base("country")
        {
        }
    }
}
