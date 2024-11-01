﻿using DogList.Application.Dogs;
using DogList.Domain.Core.Filtering;
using DogList.Domain.Core.Paging;
using DogList.Domain.Dogs;
using DogList.Presentation.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace DogList.Presentation.Controllers;

[ApiController]
[Route("dogs")]
[EnableRateLimiting("fixedLimiter")]
public sealed class DogController(
    IDogService dogService)
{
    [HttpGet]
    public async Task<IResult> Get([FromQuery] FilteringQuery filter, [FromQuery] PagingQuery? paging = null)
    {
        var result = await dogService.GetAsync(filter, paging);

        return result.IsSuccess
            ? Results.Ok(result.Value!.ToPagedResponse())
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