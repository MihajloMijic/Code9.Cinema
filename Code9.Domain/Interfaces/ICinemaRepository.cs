using Code9.Domain.Models;

namespace Code9.Domain.Interfaces
{
    public interface ICinemaRepository
    {
        public Task<List<Cinema>> GetAllCinemas();

        Task Add(Cinema cinema, CancellationToken cancellationToken);

        Task Update(Cinema cinema, CancellationToken cancellationToken);

        Task<Cinema> GetCinemaByIdAsync(Guid id, CancellationToken cancellationToken);

        Task Delete(Cinema cinema, CancellationToken cancellationToken);
    }
}
