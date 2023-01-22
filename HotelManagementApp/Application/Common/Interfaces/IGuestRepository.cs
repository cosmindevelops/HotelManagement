using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest> GetGuestByIdAsync(int id);

        Task<List<Guest>> GetAllGuestsAsync();

        Task AddGuestAsync(Guest guest);

        Task UpdateGuestAsync(Guest guest);

        Task DeleteGuestAsync(int id);
    }
}