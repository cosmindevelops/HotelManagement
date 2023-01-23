using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.InMemoryRepository
{
    public class InMemoryGuestRepository : IGuestRepository
    {
        private readonly List<Guest> _guestsList;

        public InMemoryGuestRepository()
        {
            _guestsList = new List<Guest>();
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await Task.FromResult(_guestsList.SingleOrDefault(g => g.Id == id));
        }

        public async Task<IEnumerable<Guest>> GetAllGuestsAsync()
        {
            return await Task.FromResult(_guestsList.AsEnumerable());
        }

        public async Task AddGuestAsync(Guest guest)
        {
            _guestsList.Add(guest);
            await Task.CompletedTask;
        }

        public async Task UpdateGuestAsync(Guest guest)
        {
            var index = _guestsList.FindIndex(g => g.Id == guest.Id);
            if (index > -1)
            {
                _guestsList[index] = guest;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteGuestAsync(int id)
        {
            var guest = _guestsList.SingleOrDefault(g => g.Id == id);
            if (guest != null)
            {
                _guestsList.Remove(guest);
            }
            await Task.CompletedTask;
        }
    }
}