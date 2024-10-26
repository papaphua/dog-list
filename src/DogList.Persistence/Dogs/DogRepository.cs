using DogList.Domain.Dogs;
using DogList.Persistence.Core;

namespace DogList.Persistence.Dogs;

public sealed class DogRepository(ApplicationDbContext dbContext)
    : Repository<Dog>(dbContext), IDogRepository
{
    private readonly ApplicationDbContext _dbContext = dbContext;
}