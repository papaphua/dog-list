using DogList.Domain.Core.Paging;
using Microsoft.EntityFrameworkCore;

namespace DogList.Persistence.Core.Paging;

public static class PageListExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, PagingQuery paging)
    {
        var totalItems = source.Count();

        if (totalItems < 1) return [];

        var items = await source
            .Skip(paging.Offset)
            .Take(paging.PageSize)
            .ToListAsync();

        return new PagedList<T>(items, paging, totalItems);
    }
}