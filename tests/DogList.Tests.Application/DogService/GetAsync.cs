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
        var filter = new FilteringQuery();
        var paging = new PagingQuery(1, 2);
        var dogList = new List<DogDto>
        {
            new()
            {
                Name = "Buddy",
                Color = "Brown",
                TailLength = 10,
                Weight = 20
            }
        };

        _dogRepositoryMock.Setup(repo => repo.GetAsync(filter, paging))
            .ReturnsAsync(dogList);

        var result = await _dogService.GetAsync(filter, paging);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(dogList);
    }
}