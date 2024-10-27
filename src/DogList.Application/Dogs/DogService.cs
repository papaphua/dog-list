﻿using AutoMapper;
using DogList.Application.Core;
using DogList.Domain.Core.Filtering;
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
    public async Task<Result<IList<DogDto>>> GetAsync(FilteringQuery filter, PagingQuery? paging)
    {
        var value = await dogRepository.GetAsync(filter, paging);
        return Result<IList<DogDto>>.Success(value);
    }

    public async Task<Result> AddAsync(DogDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name) ||
            !dto.Name.Any(char.IsLetter))
            return DogErrors.InvalidName;

        if (dto.Color.Length < 3 ||
            !dto.Color.Any(char.IsLetter))
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