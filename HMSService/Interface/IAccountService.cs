using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSService.Interface
{
    public interface IAccountService
    {
        Task<string> LoginAsync(LoginReqDto loginReqDto);
        Task<bool> CreateCustomerAsync(CreateCustomerReqDto createCustomerReqDto);
        Task<bool> CreateAdminAsync(CreateAdminReqDto createAdminReqDto);        
        Task<List<GetListCustomerResDto>> GetListCustomerAsync();
        Task<bool> UpdateCustomerInfoByIdAsync(UpdateCustomerInfoReqDto updateCustomerInfoReqDto);
        Task<bool> UpdateProfileAsync(UpdateProfileReqDto updateProfileReqDto);
    }
}
