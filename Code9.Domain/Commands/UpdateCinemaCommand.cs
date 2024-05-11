using Code9.Domain.Models;
using MediatR;


namespace Code9.Domain.Commands;

public record UpdateCinemaCommand(Guid Id, Cinema cinema) : IRequest<string>;

