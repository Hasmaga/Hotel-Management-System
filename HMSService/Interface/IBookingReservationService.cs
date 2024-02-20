using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSService.Interface
{
    public interface IBookingReservationService
    {
        Task<bool> CreateBookingReservationAsync(CreateBookingReservationReqDto newBooking);
        Task<bool> UpdateBookingReservationAsync(UpdateBookingReservationReqDto updateBooking);
        Task<bool> DeleteBookingReservationAsync(Guid bookingId);
        Task<List<GetBookingReservationResDto>> GetAllBookingReservationAsync();
        Task<List<GetBookingReservationResDto>> CreateReportBookingReservationAsync(CreateReportBookingReservationReqDto createReportBookingReservationReqDto);
        Task<List<GetBookingReservationResDto>> GetBookingReservationByCustomerAsync();
    }
}
