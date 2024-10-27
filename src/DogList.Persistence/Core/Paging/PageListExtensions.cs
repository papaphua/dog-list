using DogList.Domain.Core.Paging;
using Microsoft.EntityFrameworkCore;

namespace DogList.Persistence.Core.Paging;

public static class PageListExtensions
{
    public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> source, PagingQuery paging)
    {
        var totalItems = source.Count();
        var items = await source
            .Skip((paging.PageNumber - 1) * paging.PageSize)
            .Take(paging.PageSize)
            .ToListAsync();

        return new PagedList<T>(items, paging, totalItems);
    }
}