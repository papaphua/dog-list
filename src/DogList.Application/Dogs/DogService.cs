using AutoMapper;
using DogList.Application.Core;
using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;

namespace DogList.Application.Dogs;

public sealed class DogService(
    IDogRepository dogRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IDogService
{
    public async Task<PagedList<DogDto>> GetAsync(PagingQuery paging, DogFilter filter)
    {
        return await dogRepository.GetAsync(paging, filter);
    }

    public async Task AddAsync(DogDto dto)
    {
        var dogExists = await dogRepository.NameExists(dto.Name);

        if (dto.Name.Length == 0)
        {
            throw new Exception();
        }

        if (dto.Color.Length == 0)
        {
            throw new Exception();
        }

        if (dto.TailLength <= 0)
        {
            throw new Exception();
        }

        if (dto.Weight <= 0)
        {
            throw new Exception();
        }

        if (dogExists)
        {
            throw new Exception();
        }

        var dog = mapper.Map<Dog>(dto);
        await dogRepository.AddAsync(dog);
        await unitOfWork.SaveChangesAsync();
    }
}