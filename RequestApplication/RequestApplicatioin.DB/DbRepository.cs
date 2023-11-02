using Microsoft.EntityFrameworkCore;
using RequestApplication.Entities;
using System.Linq.Expressions;

namespace RequestApplicatioin.DB
{
    public class DbRepository<TEntity> : IDbRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly AppDbContext _context;

        public DbRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> selector)
        {
            return _context.Set<TEntity>().Where(selector).AsQueryable();
        }

        public async Task<long> AddAsync(TEntity newEntity)
        {
            var entity = await _context.Set<TEntity>().AddAsync(newEntity);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task AddRange(IEnumerable<TEntity> newEntities)
        {
            await _context.Set<TEntity>().AddRangeAsync(newEntities);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var activeEntity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
            _context.Set<TEntity>().Remove(activeEntity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity activeEntity)
        {
            _context.Set<TEntity>().Remove(activeEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().RemoveRange(entities));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().UpdateRange(entities));
            await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
