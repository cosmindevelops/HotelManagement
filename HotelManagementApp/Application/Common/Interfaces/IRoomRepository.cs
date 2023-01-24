using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room> GetRoomByIdAsync(int id);

        Task<IEnumerable<Room>> GetAllRoomsAsync();

        Task AddRoomAsync(Room room);

        Task UpdateRoomAsync(Room room);

        Task DeleteRoomAsync(int id);

    }
}