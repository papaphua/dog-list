using AutoMapper;
using DogList.Domain.Dogs;

namespace DogList.Application.Dogs;

public sealed class DogMap : Profile
{
    public DogMap()
    {
        CreateMap<Dog, DogDto>();
    }
}