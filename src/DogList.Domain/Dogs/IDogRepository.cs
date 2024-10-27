using DogList.Domain.Core;
using DogList.Domain.Core.Paging;

namespace DogList.Domain.Dogs;

public interface IDogRepository : IRepository<Dog>
{
    Task<PagedList<Dog>> GetAsync(PagingQuery paging);
}