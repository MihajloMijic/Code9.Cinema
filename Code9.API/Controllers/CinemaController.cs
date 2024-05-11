using Code9.Domain.Commands;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Code9.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private readonly IMediator _mediator;

    public CinemaController( IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("get-cinemas")]
    public async Task<ActionResult<List<Cinema>>> GetAllCinemasAsync(CancellationToken cancellationToken)
    {
        List<Cinema> ret = await _mediator.Send(new GetAllCinemasQuery(), cancellationToken);

        return Ok(ret);
    }

    [HttpPost("add-cinema")]
    public async Task<ActionResult<string>> AddCinemaAsync([FromBody] AddCinemaCommand request, CancellationToken cancellationToken)
    {
        var ret = await _mediator.Send(request, cancellationToken);

        return Ok(ret);
    }
}
