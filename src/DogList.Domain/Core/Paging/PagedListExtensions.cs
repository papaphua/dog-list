namespace DogList.Domain.Core.Paging;

/// <summary>
///     Provides extension methods for creating paged lists from collections.
/// </summary>
public static class PagedListExtensions
{
    /// <summary>
    ///     Converts an <see cref="IEnumerable{T}" /> collection into a <see cref="PagedList{T}" /> with the specified paging
    ///     information.
    /// </summary>
    /// <typeparam name="T">The type of items in the collection.</typeparam>
    /// <param name="collection">The collection of items to convert.</param>
    /// <param name="info">The paging information to associate with the new paged list.</param>
    /// <returns>A <see cref="PagedList{T}" /> containing the items and the specified paging information.</returns>
    public static PagedList<T> AsPagedList<T>(this IEnumerable<T> collection, PagingInfo info)
    {
        return new PagedList<T>(collection, info);
    }
}