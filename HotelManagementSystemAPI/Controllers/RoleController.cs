using HMSBuinessObject.Model.RequestDto;
using HMSService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelManagementSystemAPI.Controllers
{    
    [ApiController]
    [Route("RoleApi")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("CreateRole")]
        [Authorize]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleReqDto newRole)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = await _roleService.CreateRoleAsync(newRole);
                    if (result)
                    {
                        return Ok("Role Created Successfully");
                    }
                    return BadRequest("Role Creation Failed");
                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error Creating Role");
                }
            }
            return BadRequest("Invalid Data");
        }

        [HttpGet]
        [Route("GetAllRoles")]
        [EnableQuery]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var result = await _roleService.GetAllRolesAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Fetching Roles");
            }
        }
    }
}
