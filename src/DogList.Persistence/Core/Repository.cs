using DogList.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace DogList.Persistence.Core;

public abstract class Repository<TEntity>(ApplicationDbContext dbContext)
    : IRepository<TEntity>
    where TEntity : Entity
{
    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<TEntity>()
            .FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await dbContext.Set<TEntity>()
            .AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await dbContext.Set<TEntity>()
            .AddRangeAsync(entities);
    }

    public void Remove(TEntity entity)
    {
        dbContext.Set<TEntity>()
            .Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        dbContext.Set<TEntity>()
            .RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        dbContext.Set<TEntity>()
            .Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        dbContext.Set<TEntity>()
            .UpdateRange(entities);
    }
}