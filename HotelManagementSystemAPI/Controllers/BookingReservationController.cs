using HMSBuinessObject.Model.RequestDto;
using HMSService.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace HotelManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("BookingReservationApi")]
    public class BookingReservationController : Controller
    {
        private readonly IBookingReservationService _bookingReservationService;
        public BookingReservationController(IBookingReservationService bookingReservationService)
        {
            _bookingReservationService = bookingReservationService;
        }

        [HttpPost("CreateBookingReservation")]        
        public async Task<IActionResult> CreateBookingReservation([FromBody] CreateBookingReservationReqDto createBookingReservationReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _bookingReservationService.CreateBookingReservationAsync(createBookingReservationReqDto))
                {
                    return Ok("Booking reservation created successfully");
                }
                return BadRequest("Booking reservation creation failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteBookingReservation")]
        [Authorize]
        public async Task<IActionResult> DeleteBookingReservation([FromBody] Guid id)
        {
            try
            {
                if (await _bookingReservationService.DeleteBookingReservationAsync(id))
                {
                    return Ok("Booking reservation deleted successfully");
                }
                return BadRequest("Booking reservation deletion failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllBookingReservation")]
        [Authorize]
        [EnableQuery]
        public async Task<IActionResult> GetAllBookingReservation()
        {
            try
            {
                var bookingReservations = await _bookingReservationService.GetAllBookingReservationAsync();
                return Ok(bookingReservations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        [HttpPost("UpdateBookingReservation")]
        [Authorize]
        public async Task<IActionResult> UpdateBookingReservation([FromBody] UpdateBookingReservationReqDto updateBookingReservationReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _bookingReservationService.UpdateBookingReservationAsync(updateBookingReservationReqDto))
                {
                    return Ok("Booking reservation updated successfully");
                }
                return BadRequest("Booking reservation update failed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetReportBookingReservation")]
        [Authorize]
        public async Task<IActionResult> GetReportBookingReservation([FromBody] CreateReportBookingReservationReqDto createReportBookingReservationReqDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var report = await _bookingReservationService.CreateReportBookingReservationAsync(createReportBookingReservationReqDto);
                return Ok(report);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetHistoryBookingReservationByCustomer")]
        [Authorize]
        public async Task<IActionResult> GetHistoryBookingReservationByCustomer()
        {
            try
            {
                var history = await _bookingReservationService.GetBookingReservationByCustomerAsync();
                return Ok(history);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }   
}
