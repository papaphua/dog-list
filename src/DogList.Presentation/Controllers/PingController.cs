using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DogList.Presentation.Controllers;

[ApiController]
[Route("ping")]
[EnableRateLimiting("fixedLimiter")]
public sealed class PingController
{
    private const string Ver = "Dogshouseservice.Version1.0.1";

    [HttpGet]
    public IResult Ping()
    {
        return Results.Ok(Ver);
    }
}