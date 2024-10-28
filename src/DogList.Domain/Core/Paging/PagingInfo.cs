namespace DogList.Domain.Core.Paging;

/// <summary>
///     Represents information about paging for a list of items.
/// </summary>
public class PagingInfo
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PagingInfo" /> class based on the provided paging query and total item
    ///     count.
    /// </summary>
    /// <param name="paging">The paging query containing page number and size.</param>
    /// <param name="totalItems">The total number of items available.</param>
    public PagingInfo(PagingQuery paging, int totalItems)
    {
        PageNumber = paging.PageNumber;
        PageSize = paging.PageSize;
        TotalItems = totalItems;
        TotalPages = (int)Math.Ceiling(totalItems / (double)paging.PageSize);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PagingInfo" /> class with a single page containing all items.
    /// </summary>
    /// <param name="totalItems">The total number of items available.</param>
    public PagingInfo(int totalItems)
    {
        PageNumber = 1;
        PageSize = totalItems;
        TotalItems = totalItems;
        TotalPages = 1;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PagingInfo" /> class with default values.
    /// </summary>
    public PagingInfo()
    {
    }

    /// <summary>
    ///     Gets the current page number.
    /// </summary>
    public int PageNumber { get; }

    /// <summary>
    ///     Gets the size of each page.
    /// </summary>
    public int PageSize { get; }

    /// <summary>
    ///     Gets the total number of items available.
    /// </summary>
    public int TotalItems { get; }

    /// <summary>
    ///     Gets the total number of pages based on total items and page size.
    /// </summary>
    public int TotalPages { get; }

    /// <summary>
    ///     Gets a value indicating whether there is a next page.
    /// </summary>
    public bool HasNextPage => PageNumber < TotalPages;

    /// <summary>
    ///     Gets a value indicating whether there is a previous page.
    /// </summary>
    public bool HasPreviousPage => PageNumber > 1;
}