namespace DogList.Domain.Core.Paging;

public class PagingInfo(PagingQuery paging, int totalItems)
{
    public int PageNumber { get; } = paging.PageNumber;

    public int PageSize { get; } = paging.PageSize;

    public int TotalItems { get; } = totalItems;

    public int TotalPages { get; } = (int)Math.Ceiling(totalItems / (double)paging.PageSize);

    public bool HasNextPage => PageNumber < TotalPages;

    public bool HasPreviousPage => PageNumber > 1;
}