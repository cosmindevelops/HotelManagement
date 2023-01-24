using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly ApplicationDBContext _context;

        public RoomTypeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<RoomType> GetRoomTypeByIdAsync(int id)
        {
            return await _context.RoomTypes.FirstOrDefaultAsync(rt => rt.Id == id);
        }

        public async Task<List<RoomType>> GetAllRoomTypesAsync()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task AddRoomTypeAsync(RoomType roomType)
        {
            await _context.RoomTypes.AddAsync(roomType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomTypeAsync(RoomType roomType)
        {
            _context.RoomTypes.Update(roomType);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoomTypeAsync(int id)
        {
            //var roomType = await _context.RoomTypes.FindAsync(id);
            //_context.RoomTypes.Remove(roomType);
            //await _context.SaveChangesAsync();
            var roomType = await _context.RoomTypes.FirstOrDefaultAsync(rt => rt.Id == id);
            _context.RoomTypes.Remove(roomType);
            await _context.SaveChangesAsync();
        }
    }
}