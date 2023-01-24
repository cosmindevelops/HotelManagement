using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.InMemoryRepository
{
    public class InMemoryRoomTypeRepository : IRoomTypeRepository
    {
        private readonly List<RoomType> _roomTypes;

        public InMemoryRoomTypeRepository()
        {
            _roomTypes = new List<RoomType>();
        }

        public Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            return Task.FromResult(_roomTypes.SingleOrDefault(rt => rt.Id == id));
        }

        public Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return Task.FromResult(_roomTypes);
        }

        public Task AddRoomTypeAsync(RoomType roomType)
        {
            _roomTypes.Add(roomType);
            return Task.CompletedTask;
        }

        public Task UpdateRoomTypeAsync(RoomType roomType)
        {
            var index = _roomTypes.FindIndex(rt => rt.Id == roomType.Id);
            if (index != -1)
            {
                _roomTypes[index] = roomType;
            }
            return Task.CompletedTask;
        }

        public Task DeleteRoomTypeAsync(int id)
        {
            var index = _roomTypes.FindIndex(rt => rt.Id == id);
            if (index != -1)
            {
                _roomTypes.RemoveAt(index);
            }
            return Task.CompletedTask;
        }
    }
}