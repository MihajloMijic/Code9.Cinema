

using Code9.Domain.Commands;
using Code9.Domain.Interfaces;
using Code9.Domain.Models;
using MediatR;

namespace Code9.Domain.Handlers;

internal class AddCinemaCommandHandler : IRequestHandler<AddCinemaCommand, string>
{
    private readonly ICinemaRepository _cinemaRepository;

    public AddCinemaCommandHandler(ICinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }
    
    public async Task<string> Handle(AddCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = new Cinema(request.Name, request.City, request.Street, request.NumberOfAuditoriums);

        await _cinemaRepository.Add(cinema, cancellationToken);

        return "Cinema added successfully";
    }
}
