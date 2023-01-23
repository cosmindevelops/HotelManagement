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

        public async Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            return await Task.FromResult(_roomTypes.SingleOrDefault(rt => rt.Id == id));
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync()
        {
            return await Task.FromResult(_roomTypes.AsEnumerable());
        }

        public async Task AddRoomTypeAsync(RoomType roomType)
        {
            _roomTypes.Add(roomType);
             await Task.CompletedTask;
        }

        public async Task UpdateRoomTypeAsync(RoomType roomType)
        {
            var index = _roomTypes.FindIndex(rt => rt.Id == roomType.Id);
            if (index != -1)
            {
                _roomTypes[index] = roomType;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteRoomTypeAsync(int id)
        {
            var index = _roomTypes.FindIndex(rt => rt.Id == id);
            if (index != -1)
            {
                _roomTypes.RemoveAt(index);
            }
            await Task.CompletedTask;
        }
    }
}