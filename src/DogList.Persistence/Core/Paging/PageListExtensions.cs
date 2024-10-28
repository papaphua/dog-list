using DogList.Domain.Core.Paging;
using Microsoft.EntityFrameworkCore;

namespace DogList.Persistence.Core.Paging;

/// <summary>
/// Provides extension methods for creating paged lists from collections.
/// </summary>
public static class PageListExtensions
{
    /// <summary>
    /// Converts an IQueryable source into a PagedList asynchronously, based on the provided PagingQuery.
    /// </summary>
    /// <typeparam name="T">The type of elements in the source.</typeparam>
    /// <param name="source">The source of data to paginate.</param>
    /// <param name="paging">The paging information containing page number and page size.</param>
    /// <returns>A Task representing the asynchronous operation, with a PagedList containing the paginated results.</returns>
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, PagingQuery paging)
    {
        var totalItems = source.Count();

        if (totalItems < 1) return [];

        var items = await source
            .Skip(paging.Offset())
            .Take(paging.PageSize)
            .ToListAsync();

        return new PagedList<T>(items, paging, totalItems);
    }
}