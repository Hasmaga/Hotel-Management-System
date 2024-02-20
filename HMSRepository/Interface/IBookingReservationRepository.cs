using HMSBuinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSRepository.Interface
{
    public interface IBookingReservationRepository
    {
        Task<BookingReservation?> GetBookingReservationByRoomIdAsync(Guid roomId);
        Task<bool> CreateBookingReservationAsync(BookingReservation bookingReservation);
        Task<List<BookingReservation>> GetAllBookingReservationAsync();
        Task<bool> UpdateBookingReservationAsync(BookingReservation bookingReservation);        
        Task<BookingReservation?> GetBookingReservationByIdAsync(Guid id);
    }
}
