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

    public async Task<IList<DogDto>> GetAsync(FilteringQuery filter, PagingQuery? paging)
    {
        var query = _dbContext
            .Set<Dog>()
            .OrderBy($"{filter.Attribute ?? nameof(Dog.Name)} {filter.Order}")
            .ProjectTo<DogDto>(mapper.ConfigurationProvider);

        if (paging is { PageNumber: > 0, PageSize: > 0 }) return await query.ToPagedListAsync(paging);

        return await query.ToListAsync();
    }

    public async Task<bool> NameExists(string name)
    {
        return await _dbContext
            .Set<Dog>()
            .AnyAsync(dog => dog.Name == name);
    }
}