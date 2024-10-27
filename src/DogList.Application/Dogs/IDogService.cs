using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;

namespace DogList.Application.Dogs;

public interface IDogService
{
    Task<PagedList<DogDto>> GetAsync(PagingQuery paging, DogFilter filter);
}