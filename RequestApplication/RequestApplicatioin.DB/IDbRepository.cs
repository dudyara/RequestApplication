using RequestApplication.Entities;
using System.Linq.Expressions;

namespace RequestApplicatioin.DB
{
    public interface IDbRepository<TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> selector);
        IQueryable<TEntity> Get();
        Task<long> AddAsync(TEntity newEntity);
        Task AddRange(IEnumerable<TEntity> newEntities);
        Task DeleteAsync(long id);
        Task DeleteAsync(TEntity activeEntity);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);
        Task UpdateAsync(TEntity entity);
        Task UpdateRange(IEnumerable<TEntity> entities);
        Task<int> SaveChangesAsync();
    }
}
