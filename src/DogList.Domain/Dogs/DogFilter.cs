using DogList.Domain.Core.Filtering;

namespace DogList.Domain.Dogs;

public sealed record DogFilter(
    string Attribute = nameof(Dog.Name),
    string Order = "asc")
    : FilteringQuery(Attribute, Order);