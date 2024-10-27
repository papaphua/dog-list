namespace DogList.Domain.Core.Paging;

public sealed class PagedResponse<TData>(PagedList<TData> data, PagingInfo info)
{
    public PagedList<TData> Data { get; set; } = data;

    public PagingInfo Info { get; set; } = info;
}