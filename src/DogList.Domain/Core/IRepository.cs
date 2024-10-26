namespace DogList.Domain.Core;

public interface IRepository<TEntity>
    where TEntity : Entity
{
    Task<TEntity?> GetByIdAsync(Guid id);

    Task AddAsync(TEntity entity);

    Task AddRangeAsync(IEnumerable<TEntity> entities);

    void Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void UpdateRange(IEnumerable<TEntity> entities);
}