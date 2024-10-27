using AutoMapper;
using DogList.Domain.Dogs;
using DogList.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DogList.Tests.Persistence.DogRepository;

public sealed class NameExists
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DogList.Persistence.Dogs.DogRepository _dogRepository;

    public NameExists()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Dog, DogDto>();
            cfg.CreateMap<DogDto, Dog>();
        });

        var mapper = config.CreateMapper();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;
        _dbContext = new ApplicationDbContext(options);

        _dogRepository = new DogList.Persistence.Dogs.DogRepository(_dbContext, mapper);
    }

    [Fact]
    public async Task NameExists_ShouldReturnTrue_WhenNameExists()
    {
        var dog = new Dog { Name = "Buddy", Color = "Brown", TailLength = 10, Weight = 20 };

        await _dbContext.Set<Dog>().AddAsync(dog);
        await _dbContext.SaveChangesAsync();

        var exists = await _dogRepository.NameExists("Buddy");

        exists.Should().BeTrue();
    }

    [Fact]
    public async Task NameExists_ShouldReturnFalse_WhenNameDoesNotExist()
    {
        var exists = await _dogRepository.NameExists("SomeUnknownDogName");

        exists.Should().BeFalse();
    }
}