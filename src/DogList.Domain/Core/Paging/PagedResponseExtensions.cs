namespace DogList.Domain.Core.Paging;

/// <summary>
///     Provides extension methods for converting paged lists into paged responses.
/// </summary>
public static class PagedResponseExtensions
{
    /// <summary>
    ///     Converts a <see cref="PagedList{TData}" /> into a <see cref="PagedResponse{TData}" />.
    /// </summary>
    /// <typeparam name="TData">The type of data contained in the paged list.</typeparam>
    /// <param name="list">The paged list to convert.</param>
    /// <returns>A <see cref="PagedResponse{TData}" /> containing the data and associated paging information.</returns>
    public static PagedResponse<TData> ToPagedResponse<TData>(this PagedList<TData> list)
    {
        return new PagedResponse<TData>(list, list.Info);
    }
}