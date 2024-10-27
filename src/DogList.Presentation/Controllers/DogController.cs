using DogList.Application.Dogs;
using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DogList.Presentation.Controllers;

[ApiController]
[Route("api/dogs")]
public sealed class DogController(
    IDogService dogService)
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery] PagingQuery paging, [FromQuery] DogFilter filter)
    {
        var dogs = await dogService.GetAsync(paging, filter);
        return Results.Ok(dogs);
    }

    [HttpPost]
    public async Task<IResult> Add(DogDto dto)
    {
        await dogService.AddAsync(dto);
        return Results.Ok();
    }
}