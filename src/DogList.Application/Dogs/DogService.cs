using AutoMapper;
using DogList.Application.Core;
using DogList.Domain.Core.Paging;
using DogList.Domain.Core.Results;
using DogList.Domain.Dogs;

namespace DogList.Application.Dogs;

public sealed class DogService(
    IDogRepository dogRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper)
    : IDogService
{
    public async Task<Result<List<DogDto>>> GetAsync(DogFilter filter)
    {
        return await dogRepository.GetAsync(filter);
    }

    public async Task<Result<PagedList<DogDto>>> GetAsync(DogFilter filter, PagingQuery paging)
    {
        return await dogRepository.GetAsync(filter, paging);
    }

    public async Task<Result> AddAsync(DogDto dto)
    {
        if (dto.Name.Length == 0)
            return DogErrors.InvalidName;

        if (dto.Color.Length == 0)
            return DogErrors.InvalidColor;

        if (dto.TailLength <= 0)
            return DogErrors.InvalidTailLength;

        if (dto.Weight <= 0)
            return DogErrors.InvalidWeight;

        if (await dogRepository.NameExists(dto.Name))
            return DogErrors.AlreadyExists;

        var dog = mapper.Map<Dog>(dto);

        try
        {
            await dogRepository.AddAsync(dog);
            await unitOfWork.SaveChangesAsync();
        }
        catch (Exception)
        {
            return DogErrors.AddError;
        }

        return Result.Success();
    }
}