using DogList.Domain.Core;

namespace DogList.Domain.Dogs;

public sealed class Dog : Entity
{
    public string Name { get; set; }

    public string Color { get; set; }

    public int TailLength { get; set; }

    public int Weight { get; set; }
}