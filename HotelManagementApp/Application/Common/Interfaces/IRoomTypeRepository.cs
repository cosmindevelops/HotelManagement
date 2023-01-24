using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IRoomTypeRepository
    {
        Task<RoomType> GetRoomTypeByIdAsync(int id);

        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();

        Task AddRoomTypeAsync(RoomType roomType);

        Task UpdateRoomTypeAsync(RoomType roomType);

        Task DeleteRoomTypeAsync(int id);
    }
}