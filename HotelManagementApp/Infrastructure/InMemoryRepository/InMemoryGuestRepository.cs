using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.InMemoryRepository
{
    public class InMemoryGuestRepository : IGuestRepository
    {
        private readonly List<Guest> _guests;

        public InMemoryGuestRepository()
        {
            _guests = new List<Guest>();
        }

        public async Task<Guest> GetGuestByIdAsync(int id)
        {
            return await Task.FromResult(_guests.SingleOrDefault(g => g.Id == id));
        }

        public async Task<List<Guest>> GetAllGuestsAsync()
        {
            return await Task.FromResult(_guests);
        }

        public async Task AddGuestAsync(Guest guest)
        {
            _guests.Add(guest);
            await Task.CompletedTask;
        }

        public async Task UpdateGuestAsync(Guest guest)
        {
            var index = _guests.FindIndex(g => g.Id == guest.Id);
            if (index > -1)
            {
                _guests[index] = guest;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteGuestAsync(int id)
        {
            var guest = _guests.SingleOrDefault(g => g.Id == id);
            if (guest != null)
            {
                _guests.Remove(guest);
            }
            await Task.CompletedTask;
        }
    }
}