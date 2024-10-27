using DogList.Domain.Core;
using DogList.Domain.Core.Filtering;
using DogList.Domain.Core.Paging;

namespace DogList.Domain.Dogs;

public interface IDogRepository : IRepository<Dog>
{
    Task<IList<Dog>> GetAsync(FilteringQuery filter, PagingQuery? paging);

    Task<bool> NameExists(string name);
}