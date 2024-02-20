using HMSBuinessObject.Model.RequestDto;
using HMSService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("AccountApi")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("CreateAdmin")]
        [Authorize]
        public async Task<IActionResult> CreateAdmin([FromBody] CreateAdminReqDto createAdminReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _accountService.CreateAdminAsync(createAdminReqDto))
                {
                    return Ok("Admin created successfully");
                }
                return BadRequest("Admin creation failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerReqDto createCustomerReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _accountService.CreateCustomerAsync(createCustomerReqDto))
                {
                    return Ok("Customer created successfully");
                }
                return BadRequest("Customer creation failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginReqDto loginReqDto)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var token = await _accountService.LoginAsync(loginReqDto);
                if (token != null)
                {
                    return Ok(token);
                }
                return BadRequest("Login failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetListCustomer")]
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> GetListCustomer()
        {
            try
            {
                var listCustomer = await _accountService.GetListCustomerAsync();
                return Ok(listCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCustomerInfoById")]
        [Authorize]
        public async Task<IActionResult> UpdateCustomerInfoById([FromBody] UpdateCustomerInfoReqDto updateCustomerInfoReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _accountService.UpdateCustomerInfoByIdAsync(updateCustomerInfoReqDto))
                {
                    return Ok("Customer updated successfully");
                }
                return BadRequest("Customer update failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProfile")]
        [Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileReqDto updateProfileReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _accountService.UpdateProfileAsync(updateProfileReqDto))
                {
                    return Ok("Profile updated successfully");
                }
                return BadRequest("Profile update failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
