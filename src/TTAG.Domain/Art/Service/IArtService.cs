namespace TTAG.Domain.Service
{
    using System.Threading.Tasks;
    using Model;

    public interface IArtService
    {
        Task<Art> AddOrUpdate(Art art);
    }
}
