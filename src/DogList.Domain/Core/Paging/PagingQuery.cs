namespace DogList.Domain.Core.Paging;

public sealed record PagingQuery(
    int PageNumber = 1,
    int PageSize = 10);