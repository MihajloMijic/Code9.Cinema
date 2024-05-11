using Code9.Domain.Commands;
using Code9.Domain.Models;
using Code9.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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

    [HttpPost("update-cinema/{Id}")]
    public async Task<ActionResult<string>> UpdateCinemaAsync(Guid Id, [FromBody] Cinema cinema, CancellationToken cancellationToken)
    {
        var ret = await _mediator.Send(new UpdateCinemaCommand(Id,cinema), cancellationToken);

        return ret == String.Empty
            ? NotFound("There is no cinema with given ID")
            : Ok(ret);
    }

    [HttpPost("delete-cinema/{Id}")]
    public async Task<ActionResult<string>> DeleteCinemaAsync(Guid Id, CancellationToken cancellationToken)
    {
        var ret = await _mediator.Send(new DeleteCinemaCommand(Id), cancellationToken);

        return ret == String.Empty
            ? NotFound("There is no cinema with given ID")
            : Ok(ret);
    }
}
