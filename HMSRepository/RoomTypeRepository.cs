using HMSBuinessObject.HMSDbContext;
using HMSBuinessObject.Model;
using HMSRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HMSRepository
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HMSDBContexts _db;
        public RoomTypeRepository(HMSDBContexts db)
        {
            _db = db;
        }

        public async Task<bool> CreateRoomTypeAsync(RoomType roomType)
        {
            try
            {
                await _db.RoomTypes.AddAsync(roomType);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RoomType>> GetListRoomTypeAsync()
        {
            try
            {
                return await _db.RoomTypes.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomType?> GetRoomTypeByIdAsync(Guid id)
        {
            try
            {
                return await _db.RoomTypes.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomType?> GetRoomTypeByName(string name)
        {
            try
            {
                return await _db.RoomTypes.FirstOrDefaultAsync(roomType => roomType.RoomTypeName == name);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
