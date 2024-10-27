using DogList.Application.Dogs;
using DogList.Domain.Core.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogList.Presentation.Controllers;

[ApiController]
[Route("api/dogs")]
public sealed class DogController(
    IDogService dogService)
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery] PagingQuery paging)
    {
        var dogs = await dogService.GetAsync(paging);
        return Results.Ok(dogs);
    }
}