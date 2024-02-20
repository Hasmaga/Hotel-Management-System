using HMSBuinessObject.Model;
using HMSBuinessObject.Model.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSRepository.Interface
{
    public interface IRoomTypeRepository
    {
        Task<bool> CreateRoomTypeAsync(RoomType roomType);
        Task<RoomType?> GetRoomTypeByName(string name);
        Task<List<RoomType>> GetListRoomTypeAsync();
        Task<RoomType?> GetRoomTypeByIdAsync(Guid id);
    }
}
