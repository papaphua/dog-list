namespace DogList.Domain.Core.Paging;

/// <summary>
///     Represents a paged collection of items, inheriting from <see cref="List{T}" />.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
public sealed class PagedList<T> : List<T>
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="PagedList{T}" /> class with the specified items, paging query, and
    ///     total items.
    /// </summary>
    /// <param name="items">The list of items for this page.</param>
    /// <param name="query">The paging query used to retrieve this page.</param>
    /// <param name="totalItems">The total number of items across all pages.</param>
    public PagedList(List<T> items, PagingQuery query, int totalItems)
    {
        Info = new PagingInfo(query, totalItems);
        AddRange(items);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PagedList{T}" /> class with the specified items and paging
    ///     information.
    /// </summary>
    /// <param name="items">The collection of items for this page.</param>
    /// <param name="info">The paging information associated with the items.</param>
    public PagedList(IEnumerable<T> items, PagingInfo info)
    {
        Info = info;
        AddRange(items);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PagedList{T}" /> class using a specified list of items.
    /// </summary>
    /// <param name="items">The list of items for this page.</param>
    public PagedList(IList<T> items)
    {
        Info = new PagingInfo(items.Count);
        AddRange(items);
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="PagedList{T}" /> class with default values.
    /// </summary>
    public PagedList()
    {
        Info = new PagingInfo();
    }

    /// <summary>
    ///     Gets the paging information associated with this paged list.
    /// </summary>
    public PagingInfo Info { get; }
}