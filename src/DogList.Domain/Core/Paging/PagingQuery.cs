namespace DogList.Domain.Core.Paging;

public sealed record PagingQuery(
    int PageNumber,
    int PageSize);