using MediatR;

namespace Code9.Domain.Commands;

public record AddCinemaCommand(string Name, string City, string Street, int NumberOfAuditoriums) : IRequest<string>;


