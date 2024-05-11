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
    public async Task<ActionResult<List<Cinema>>> GetAllCinemas(CancellationToken cancellationToken)
    {
        List<Cinema> ret = await _mediator.Send(new GetAllCinemasQuery(), cancellationToken);

        return Ok(ret);
    }
}
