using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IGuestRepository
    {
        Task<Guest> GetGuestByIdAsync(int id);

        Task<IEnumerable<Guest>> GetAllGuestsAsync();

        Task AddGuestAsync(Guest guest);

        Task UpdateGuestAsync(Guest guest);

        Task DeleteGuestAsync(int id);

        Task<Guest> GetGuestByFullName(string firstName, string lastName);
    }
}