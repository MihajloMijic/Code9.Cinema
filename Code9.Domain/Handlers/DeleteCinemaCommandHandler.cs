using Code9.Domain.Commands;
using Code9.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code9.Domain.Handlers;

internal class DeleteCinemaCommandHandler : IRequestHandler<DeleteCinemaCommand, string>
{
    private readonly ICinemaRepository _cinemaRepository;

    public DeleteCinemaCommandHandler(ICinemaRepository cinemaRepository)
    {
        _cinemaRepository = cinemaRepository;
    }

    public async Task<string> Handle(DeleteCinemaCommand request, CancellationToken cancellationToken)
    {
        var cinema = await _cinemaRepository.GetCinemaByIdAsync(request.Id, cancellationToken);

        if (cinema is null)
        {
            return string.Empty;
        }

        await _cinemaRepository.Delete(cinema, cancellationToken);

        return "Cinema deleted successfully";
    }
}
