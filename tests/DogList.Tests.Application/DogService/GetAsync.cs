using AutoMapper;
using DogList.Application.Core;
using DogList.Domain.Core.Filtering;
using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;
using FluentAssertions;
using Moq;

namespace DogList.Tests.Application.DogService;

public sealed class GetAsync
{
    private readonly Mock<IDogRepository> _dogRepositoryMock;
    private readonly DogList.Application.Dogs.DogService _dogService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public GetAsync()
    {
        _dogRepositoryMock = new Mock<IDogRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new();
        _dogService =
            new DogList.Application.Dogs.DogService(_dogRepositoryMock.Object, _unitOfWorkMock.Object,
                mapperMock.Object);
    }

    [Fact]
    public async Task GetAsync_ShouldReturnDogs()
    {
        var filter = new FilteringQuery
        {
            Attribute = "Name",
            Order = "asc"
        };

        var pageNumber = 1;
        var pageSize = 2;
        var paging = new PagingQuery(pageNumber, pageSize);

        var dogs = new List<Dog>
        {
            new() { Name = "Buddy", Color = "Brown", TailLength = 10, Weight = 20 },
            new() { Name = "Max", Color = "Black", TailLength = 15, Weight = 25 }
        };
        var pagedDogs = new PagedList<Dog>(dogs, paging, 2);

        _dogRepositoryMock
            .Setup(repo => repo.GetAsync(filter, paging))
            .ReturnsAsync(pagedDogs);

        var result = await _dogService.GetAsync(filter, paging);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value.Should().BeOfType<PagedList<DogDto>>();
        var pagedResult = result.Value;
        pagedResult?.Info.Should().NotBeNull();
        pagedResult?.Info.TotalPages.Should().Be((int)Math.Ceiling(dogs.Count / (double)pageSize));
        pagedResult?.Info.TotalItems.Should().Be(pageSize);
    }
}