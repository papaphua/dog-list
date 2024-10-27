namespace DogList.Domain.Core.Filtering;

public abstract record FilteringQuery(
    string? Attribute = null,
    string Order = "asc");