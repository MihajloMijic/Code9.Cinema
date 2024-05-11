using Code9.Domain.Models;
using MediatR;

namespace Code9.Domain.Queries;
public record  GetAllCinemasQuery() : IRequest<List<Cinema>>;

