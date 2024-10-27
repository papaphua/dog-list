using System.Linq.Dynamic.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DogList.Domain.Core.Filtering;
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

    public async Task<List<DogDto>> GetAsync(FilteringQuery filter)
    {
        var query = _dbContext
            .Set<Dog>()
            .AsQueryable();

        if (filter.Attribute != null) query = query.OrderBy($"{filter.Attribute} {filter.Order}");

        return await query
            .ProjectTo<DogDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<PagedList<DogDto>> GetAsync(FilteringQuery filter, PagingQuery paging)
    {
        var query = _dbContext
            .Set<Dog>()
            .AsQueryable();

        if (filter.Attribute != null) query = query.OrderBy($"{filter.Attribute} {filter.Order}");

        return await query
            .ProjectTo<DogDto>(mapper.ConfigurationProvider)
            .ToPagedListAsync(paging);
    }

    public async Task<bool> NameExists(string name)
    {
        return await _dbContext
            .Set<Dog>()
            .AnyAsync(dog => dog.Name == name);
    }
}