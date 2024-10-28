namespace DogList.Domain.Core.Paging;

/// <summary>
/// Represents a paged response containing a list of data and associated paging information.
/// </summary>
/// <typeparam name="TData">The type of data contained in the response.</typeparam>
public sealed class PagedResponse<TData>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResponse{TData}"/> class with the specified data and paging information.
    /// </summary>
    /// <param name="data">The paged list of data items.</param>
    /// <param name="info">The paging information associated with the data.</param>
    public PagedResponse(PagedList<TData> data, PagingInfo info)
    {
        Data = data;
        Info = info;
    }

    /// <summary>
    /// Gets or sets the paged list of data items.
    /// </summary>
    public PagedList<TData> Data { get; set; }

    /// <summary>
    /// Gets or sets the paging information associated with the data.
    /// </summary>
    public PagingInfo Info { get; set; }
}