using HMSBuinessObject.HMSDbContext;
using HMSBuinessObject.Model;
using HMSRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSRepository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HMSDBContexts _db;

        public RoomRepository(HMSDBContexts db)
        {
            _db = db;
        }

        public async Task<bool> CreateRoomAsync(RoomInformation room)
        {
            try
            {
                await _db.RoomInformations.AddAsync(room);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteRoomAsync(RoomInformation room)
        {
            try
            {                
                _db.RoomInformations.Remove(room);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RoomInformation>> GetListRoomAsync()
        {
            try
            {
                return await _db.RoomInformations.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomInformation?> GetRoomByIdAsync(Guid id)
        {
            try
            {
                return await _db.RoomInformations.FindAsync(id);                 
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateRoomAsync(RoomInformation room)
        {
            try
            {
                _db.RoomInformations.Update(room);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
