namespace DogList.Domain.Core;

/// <summary>
///     Defines a generic repository interface for managing entities that implement the <see cref="IEntity" /> marker
///     interface.
/// </summary>
/// <typeparam name="TEntity">The type of the entity, which must be a class and implement <see cref="IEntity" />.</typeparam>
public interface IRepository<in TEntity>
    where TEntity : class, IEntity
{
    /// <summary>
    ///     Asynchronously adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    Task AddAsync(TEntity entity);

    /// <summary>
    ///     Asynchronously adds a range of new entities to the repository.
    /// </summary>
    /// <param name="entities">The entities to add.</param>
    /// <returns>A collection of the added entities.</returns>
    Task AddRangeAsync(IEnumerable<TEntity> entities);

    /// <summary>
    ///     Asynchronously removes an entity from the repository.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    void Remove(TEntity entity);

    /// <summary>
    ///     Asynchronously removes a range of entities from the repository.
    /// </summary>
    /// <param name="entities">The entities to remove.</param>
    void RemoveRange(IEnumerable<TEntity> entities);

    /// <summary>
    ///     Asynchronously updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    void Update(TEntity entity);

    /// <summary>
    ///     Asynchronously updates a range of entities in the repository.
    /// </summary>
    /// <param name="entities">The entities to update.</param>
    void UpdateRange(IEnumerable<TEntity> entities);
}