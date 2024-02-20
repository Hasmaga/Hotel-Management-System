using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSService.Interface
{
    public interface IRoomService
    {        
        Task<bool> CreateRoomAsync(CreateRoomInformationReqDto newRoom);
        Task<List<GetRoomResDto>> GetListRoomAsync();
        Task<bool> UpdateRoomAsync(UpdateRoomReqDto room);
        Task<bool> DeleteRoomAsync(Guid id);        
    }
}
