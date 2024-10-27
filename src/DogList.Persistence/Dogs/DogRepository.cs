using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;
using DogList.Persistence.Core;
using DogList.Persistence.Core.Paging;

namespace DogList.Persistence.Dogs;

public sealed class DogRepository(ApplicationDbContext dbContext)
    : Repository<Dog>(dbContext), IDogRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<PagedList<Dog>> GetAsync(PagingQuery paging)
    {
        return await _dbContext
            .Set<Dog>()
            .ToPagedListAsync(paging);
    }
}