namespace DogList.Domain.Core.Filtering;

public abstract record FilteringQuery(
    string Attribute,
    string Order);