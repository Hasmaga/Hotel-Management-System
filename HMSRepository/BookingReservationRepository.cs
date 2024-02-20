using HMSBuinessObject.HMSDbContext;
using HMSBuinessObject.Model;
using HMSRepository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSRepository
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        private readonly HMSDBContexts _db;

        public BookingReservationRepository(HMSDBContexts db)
        {
            _db = db;
        }

        public async Task<bool> CreateBookingReservationAsync(BookingReservation bookingReservation)
        {
            try
            {
                await _db.BookingReservations.AddAsync(bookingReservation);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<BookingReservation>> GetAllBookingReservationAsync()
        {
            try
            {
                return await _db.BookingReservations.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<BookingReservation?> GetBookingReservationByIdAsync(Guid id)
        {
            try
            {
                return await _db.BookingReservations.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<BookingReservation?> GetBookingReservationByRoomIdAsync(Guid roomId)
        {
            try
            {
                return await _db.BookingReservations.Where(x => x.RoomInformationId == roomId).FirstOrDefaultAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateBookingReservationAsync(BookingReservation bookingReservation)
        {
            try
            {
                _db.BookingReservations.Update(bookingReservation);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
