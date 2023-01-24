using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.InMemoryRepository
{
    public class InMemoryRoomRepository : IRoomRepository
    {
        private readonly List<Room> _rooms;

        public InMemoryRoomRepository()
        {
            _rooms = new List<Room>();
        }

        public async Task<Room> GetRoomByIdAsync(int id)
        {
            return await Task.FromResult(_rooms.SingleOrDefault(r => r.Id == id));
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            return await Task.FromResult(_rooms);
        }

        public async Task AddRoomAsync(Room room)
        {
            _rooms.Add(room);
            await Task.CompletedTask;
        }

        public async Task UpdateRoomAsync(Room room)
        {
            var index = _rooms.FindIndex(r => r.Id == room.Id);
            if (index > -1)
            {
                _rooms[index] = room;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteRoomAsync(int id)
        {
            var room = _rooms.SingleOrDefault(r => r.Id == id);
            if (room != null)
            {
                _rooms.Remove(room);
            }
            await Task.CompletedTask;
        }
    }
}