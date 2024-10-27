namespace DogList.Domain.Core.Paging;

public sealed record PagingQuery(
    int PageNumber,
    int PageSize)
{
    public int Offset => (PageNumber - 1) * PageSize;
}