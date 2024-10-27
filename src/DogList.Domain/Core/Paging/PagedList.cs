namespace DogList.Domain.Core.Paging;

public sealed class PagedList<T> : List<T>
{
    public PagedList(List<T> items, PagingQuery query, int totalItems)
    {
        Info = new PagingInfo(query, totalItems);
        AddRange(items);
    }

    public PagingInfo Info { get; }
}