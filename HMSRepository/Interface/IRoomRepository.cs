using HMSBuinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSRepository.Interface
{
    public interface IRoomRepository
    {
        Task<bool> CreateRoomAsync(RoomInformation room);
        Task<List<RoomInformation>> GetListRoomAsync();
        Task<RoomInformation?> GetRoomByIdAsync(Guid id);
        Task<bool> UpdateRoomAsync(RoomInformation room);
        Task<bool> DeleteRoomAsync(RoomInformation room);
    }
}
