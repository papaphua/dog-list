using DogList.Domain.Core.Filtering;

namespace DogList.Domain.Dogs;

public sealed record DogFilter(
    string? Attribute,
    string Order = "asc")
    : FilteringQuery(Attribute, Order);