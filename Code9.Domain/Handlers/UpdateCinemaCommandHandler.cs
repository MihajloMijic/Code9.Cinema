using Code9.Domain.Commands;
using Code9.Domain.Interfaces;
using MediatR;


namespace Code9.Domain.Handlers;

internal class UpdateCinemaCommandHandler : IRequestHandler<UpdateCinemaCommand, string>
{
    private readonly ICinemaRepository _cinemaRepository;

    public UpdateCinemaCommandHandler(ICinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }

    public async Task<string> Handle(UpdateCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = await _cinemaRepository.GetCinemaByIdAsync(request.Id, cancellationToken);

        if (cinema is null)
        {
            return string.Empty;
        }

        cinema.Name = request.cinema.Name;
        cinema.City = request.cinema.City;
        cinema.Street = request.cinema.Street;

        await _cinemaRepository.Update(cinema, cancellationToken);

        return "Cinema updated successfully";
    }
}
