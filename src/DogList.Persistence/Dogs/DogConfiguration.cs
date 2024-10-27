using DogList.Domain.Dogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogList.Persistence.Dogs;

public sealed class DogConfiguration : IEntityTypeConfiguration<Dog>
{
    public void Configure(EntityTypeBuilder<Dog> builder)
    {
        builder.HasKey(dog => dog.Name);
    }
}