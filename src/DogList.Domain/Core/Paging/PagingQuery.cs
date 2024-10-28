namespace DogList.Domain.Core.Paging;

/// <summary>
/// Represents a query for paging, containing the page number and page size.
/// </summary>
/// <param name="PageNumber">The current page number (1-based).</param>
/// <param name="PageSize">The number of items to display per page.</param>
public sealed record PagingQuery(
    int PageNumber,
    int PageSize)
{
    /// <summary>
    /// Calculates the offset for the current page.
    /// The offset is calculated as (PageNumber - 1) * PageSize.
    /// This value is used to determine how many items to skip when querying for paged results.
    /// </summary>
    /// <returns>The calculated offset.</returns>
    public int Offset()
    {
        return (PageNumber - 1) * PageSize;
    }
}