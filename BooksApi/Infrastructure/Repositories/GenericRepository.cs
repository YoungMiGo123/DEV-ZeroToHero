using BooksApi.Core.Entities;
using BooksApi.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Infrastructure.Repositories
{
    public class GenericRepository<TEntity>(AppDbContext dbContext) : IGenericRepository<TEntity> where TEntity : Entity
    {
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await dbContext.Set<TEntity>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> UpdateAsync(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            return await dbContext.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsDeleted = true;
            return await UpdateAsync(entity);
        }
        public IQueryable<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsNoTracking();
        }
    }
}

