﻿using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;

namespace DogList.Application.Dogs;

public sealed class DogService(
    IDogRepository dogRepository)
    : IDogService
{
    public async Task<PagedList<Dog>> GetAsync(PagingQuery paging)
    {
        return await dogRepository.GetAsync(paging);
    }
}