using AutoMapper;
using DogList.Application.Core;
using DogList.Domain.Dogs;
using FluentAssertions;
using Moq;

namespace DogList.Tests.Application.DogService;

public sealed class AddAsync
{
    private readonly Mock<IDogRepository> _dogRepositoryMock;
    private readonly DogList.Application.Dogs.DogService _dogService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public AddAsync()
    {
        _dogRepositoryMock = new Mock<IDogRepository>();
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        Mock<IMapper> mapperMock = new();
        _dogService =
            new DogList.Application.Dogs.DogService(_dogRepositoryMock.Object, _unitOfWorkMock.Object,
                mapperMock.Object);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnSuccess()
    {
        var dogDto = new DogDto
        {
            Name = "Buddy",
            Color = "Brown",
            TailLength = 10,
            Weight = 25
        };

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }

    [Fact]
    public async Task AddAsync_ShouldReturnInvalidName_WhenContainsNumbers()
    {
        var dogDto = new DogDto
        {
            Name = "Bob123",
            Color = "Brown",
            TailLength = 10,
            Weight = 25
        };

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.InvalidName);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnInvalidName_WhenEmpty()
    {
        var dogDto = new DogDto
        {
            Name = string.Empty,
            Color = "Brown",
            TailLength = 10,
            Weight = 25
        };

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.InvalidName);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnInvalidColor_WhenContainsNumbers()
    {
        var dogDto = new DogDto
        {
            Name = "Buddy",
            Color = "Br4own",
            TailLength = 10,
            Weight = 25
        };

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.InvalidColor);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnInvalidColor_WhenLessThen2()
    {
        var dogDto = new DogDto
        {
            Name = "Buddy",
            Color = "Br",
            TailLength = 10,
            Weight = 25
        };

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.InvalidColor);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnInvalidColor_WhenEmpty()
    {
        var dogDto = new DogDto
        {
            Name = "Buddy",
            Color = string.Empty,
            TailLength = 10,
            Weight = 25
        };

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.InvalidColor);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnInvalidTailLength_WhenLessOrEqualToZero()
    {
        var dogDto = new DogDto
        {
            Name = "Buddy",
            Color = "Brown",
            TailLength = -7,
            Weight = 25
        };

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.InvalidTailLength);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnInvalidWeight_WhenLessOrEqualToZero()
    {
        var dogDto = new DogDto
        {
            Name = "Buddy",
            Color = "Brown",
            TailLength = 10,
            Weight = 0
        };

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.InvalidWeight);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnAlreadyExists_WhenNameAlreadyExists()
    {
        var dogDto = new DogDto
        {
            Name = "Buddy",
            Color = "Brown",
            TailLength = 10,
            Weight = 25
        };

        _dogRepositoryMock
            .Setup(repo => repo.NameExists(dogDto.Name))
            .ReturnsAsync(true);

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.AlreadyExists);
    }

    [Fact]
    public async Task AddAsync_ShouldReturnAddError_WhenExceptionIsThrown()
    {
        var dogDto = new DogDto
        {
            Name = "Buddy",
            Color = "Brown",
            TailLength = 10,
            Weight = 25
        };

        _unitOfWorkMock
            .Setup(uow => uow.SaveChangesAsync(CancellationToken.None))
            .ThrowsAsync(new Exception());

        var result = await _dogService.AddAsync(dogDto);

        result.Should().NotBeNull();
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(DogErrors.AddError);
    }
}