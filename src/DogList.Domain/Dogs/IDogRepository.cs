using DogList.Domain.Core;
using DogList.Domain.Core.Paging;

namespace DogList.Domain.Dogs;

public interface IDogRepository : IRepository<Dog>
{
    Task<PagedList<DogDto>> GetAsync(PagingQuery paging, DogFilter filter);

    Task<bool> NameExists(string name);
}