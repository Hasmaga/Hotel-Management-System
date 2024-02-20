using HMSBuinessObject.Model.RequestDto;
using HMSService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("RoomTypeApi")]
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService _roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            _roomTypeService = roomTypeService;
        }

        [HttpGet("GetAllRoomType")]
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> GetAllRoomType()
        {
            try
            {
                var roomTypes = await _roomTypeService.GetListRoomTypeAsync();
                return Ok(roomTypes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateRoomType")]
        [Authorize]
        public async Task<IActionResult> CreateRoomType([FromBody] CreateRoomTypeReqDto createRoomTypeReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _roomTypeService.CreateRoomTypeAsync(createRoomTypeReqDto))
                {
                    return Ok("Room Type created successfully");
                }
                return BadRequest("Room Type creation failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
