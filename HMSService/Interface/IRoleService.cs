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
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(CreateRoleReqDto newRole);
        Task<IEnumerable<GetRoleResDto>> GetAllRolesAsync();
    }
}
