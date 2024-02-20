using HMSBuinessObject.Model;
using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSService.Interface
{
    public interface IRoomTypeService
    {
        Task<bool> CreateRoomTypeAsync(CreateRoomTypeReqDto newRoomType);
        Task<List<GetRoomTypeResDto>> GetListRoomTypeAsync();         
    }
}
