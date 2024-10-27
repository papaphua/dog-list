using System.Linq.Dynamic.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;
using DogList.Persistence.Core;
using DogList.Persistence.Core.Paging;
using Microsoft.EntityFrameworkCore;

namespace DogList.Persistence.Dogs;

public sealed class DogRepository(
    ApplicationDbContext dbContext,
    IMapper mapper)
    : Repository<Dog>(dbContext), IDogRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<List<DogDto>> GetAsync(DogFilter filter)
    {
        return await _dbContext
            .Set<Dog>()
            .ProjectTo<DogDto>(mapper.ConfigurationProvider)
            .OrderBy($"{filter.Attribute} {filter.Order}")
            .ToListAsync();
    }

    public async Task<PagedList<DogDto>> GetAsync(DogFilter filter, PagingQuery paging)
    {
        return await _dbContext
            .Set<Dog>()
            .ProjectTo<DogDto>(mapper.ConfigurationProvider)
            .OrderBy($"{filter.Attribute} {filter.Order}")
            .ToPagedListAsync(paging);
    }

    public async Task<bool> NameExists(string name)
    {
        return await _dbContext
            .Set<Dog>()
            .AnyAsync(dog => dog.Name == name);
    }
}