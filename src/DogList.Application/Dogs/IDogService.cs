using DogList.Domain.Core.Paging;
using DogList.Domain.Core.Results;
using DogList.Domain.Dogs;

namespace DogList.Application.Dogs;

public interface IDogService
{
    Task<Result<List<DogDto>>> GetAsync(DogFilter filter);

    Task<Result<PagedList<DogDto>>> GetAsync(DogFilter filter, PagingQuery paging);

    Task<Result> AddAsync(DogDto dto);
}