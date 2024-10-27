using DogList.Application.Dogs;
using DogList.Domain.Core.Filtering;
using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;
using DogList.Presentation.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogList.Presentation.Controllers;

[ApiController]
[Route("api/dogs")]
public sealed class DogController(
    IDogService dogService)
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery] FilteringQuery filter, [FromQuery] PagingQuery? paging = null)
    {
        var hasPaging = paging is { PageNumber: > 0, PageSize: > 0 };

        dynamic result = hasPaging
            ? await dogService.GetAsync(filter, paging!)
            : await dogService.GetAsync(filter);

        return result.IsSuccess
            ? Results.Ok(result.Value)
            : result.ToProblemDetails();
    }

    [HttpPost]
    public async Task<IResult> Add(DogDto dto)
    {
        var result = await dogService.AddAsync(dto);

        return result.IsSuccess
            ? Results.Ok()
            : result.ToProblemDetails();
    }
}