using Microsoft.EntityFrameworkCore.Storage;

namespace DogList.Application.Core;

/// <summary>
///     Defines the contract for a unit of work, encapsulating database operations.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     Saves all changes made in the context of this unit of work asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Begins a new database transaction asynchronously.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token to cancel the operation, if needed.</param>
    /// <returns>An instance of <see cref="IDbContextTransaction" /> representing the transaction.</returns>
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
}