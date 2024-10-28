namespace DogList.Domain.Core.Filtering;

/// <summary>
/// Represents a query for filtering data based on specific attributes and order.
/// </summary>
/// <param name="Attribute">The attribute to filter by. Optional.</param>
/// <param name="Order">The order in which to sort the results. Default is "asc".</param>
public sealed record FilteringQuery(
    string? Attribute = null,
    string Order = "asc");