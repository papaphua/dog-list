using DogList.Application.Dogs;
using DogList.Domain.Core.Filtering;
using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;
using DogList.Presentation.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DogList.Presentation.Controllers;

[ApiController]
[Route("api/dogs")]
[EnableRateLimiting("fixedLimiter")]
public sealed class DogController(
    IDogService dogService)
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery] FilteringQuery filter, [FromQuery] PagingQuery? paging = null)
    {
        var result = await dogService.GetAsync(filter, paging);

        if (result.IsSuccess)
            return paging is { PageNumber: > 0, PageSize: > 0 }
                ? Results.Ok((result.Value as PagedList<DogDto>)!.ToPagedResponse())
                : Results.Ok(result.Value);

        return result.ToProblemDetails();
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