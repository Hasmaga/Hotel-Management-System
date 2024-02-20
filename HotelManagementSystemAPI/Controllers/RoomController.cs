using HMSBuinessObject.Model.RequestDto;
using HMSService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("RoomApi")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;            
        }

        [HttpGet("GetAllRoom")]
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> GetAllRoom()
        {
            try
            {
                var rooms = await _roomService.GetListRoomAsync();
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateRoom")]
        [Authorize]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomInformationReqDto newRoom)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _roomService.CreateRoomAsync(newRoom))
                {
                    return Ok("Room created successfully");
                }
                return BadRequest("Room creation failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteRoom")]
        [Authorize]
        public async Task<IActionResult> DeleteRoom([FromBody] Guid id)
        {
            try
            {
                if (await _roomService.DeleteRoomAsync(id))
                {
                    return Ok("Room deleted successfully");
                }
                return BadRequest("Room deletion failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateRoom")]
        [Authorize]
        public async Task<IActionResult> UpdateRoom([FromBody] UpdateRoomReqDto updateRoomReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _roomService.UpdateRoomAsync(updateRoomReqDto))
                {
                    return Ok("Room updated successfully");
                }
                return BadRequest("Room update failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
