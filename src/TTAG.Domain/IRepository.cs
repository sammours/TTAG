namespace TTAG.Domain
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TTAG.Common;

    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();

        Task<TEntity> GetByIdAsync(string id);

        Task<TEntity> AddOrUpdateAsync(TEntity entity);

        Task<bool> DeleteAsync(string id);
    }
}
