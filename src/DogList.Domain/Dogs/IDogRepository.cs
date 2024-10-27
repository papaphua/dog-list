using DogList.Domain.Core;
using DogList.Domain.Core.Paging;

namespace DogList.Domain.Dogs;

public interface IDogRepository : IRepository<Dog>
{
    Task<List<DogDto>> GetAsync(DogFilter filter);
    
    Task<PagedList<DogDto>> GetAsync(DogFilter filter, PagingQuery paging);

    Task<bool> NameExists(string name);
}