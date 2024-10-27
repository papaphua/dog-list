using AutoMapper;
using DogList.Domain.Core.Filtering;
using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;
using DogList.Persistence;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DogList.Tests.Persistence.DogRepository;

public sealed class GetAsync
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DogList.Persistence.Dogs.DogRepository _dogRepository;

    public GetAsync()
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
    public async Task GetAsync_ShouldReturnDogs()
    {
        var dogs = new List<Dog>
        {
            new() { Name = "Buddy", Color = "Brown", TailLength = 10, Weight = 20 },
            new() { Name = "Max", Color = "Black", TailLength = 15, Weight = 25 },
            new() { Name = "Alex", Color = "White", TailLength = 13, Weight = 22 },
            new() { Name = "White", Color = "Gray", TailLength = 14, Weight = 22 },
            new() { Name = "Cocos", Color = "Yellow", TailLength = 12, Weight = 17 }
        };

        await _dbContext.Set<Dog>()
            .AddRangeAsync(dogs);
        await _dbContext.SaveChangesAsync();

        var filter = new FilteringQuery
        {
            Attribute = "Name",
            Order = "asc"
        };

        var pageNumber = 1;
        var pageSize = 2;
        var paging = new PagingQuery(pageNumber, pageSize);

        var result = await _dogRepository.GetAsync(filter, paging);
        var pagedList = result as PagedList<Dog>;

        pagedList.Should().NotBeNull();
        pagedList.Should().HaveCount(pageSize);
        pagedList?.Info.Should().NotBeNull();
        pagedList?.Info.TotalPages.Should().Be((int)Math.Ceiling(dogs.Count / (double)pageSize));
        pagedList?.Info.TotalItems.Should().Be(dogs.Count);
        pagedList?[0].Name.Should().Be("Alex");
        pagedList?[1].Name.Should().Be("Buddy");
    }
}