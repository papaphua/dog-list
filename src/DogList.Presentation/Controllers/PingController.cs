using DogList.Application.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;

namespace DogList.Presentation.Controllers;

[ApiController]
[Route("ping")]
[EnableRateLimiting("fixedLimiter")]
public sealed class PingController(IOptions<AppOptions> appOptions)
{
    [HttpGet]
    public IResult Ping()
    {
        return Results.Ok(appOptions.Value.Version);
    }
}