using HMSBuinessObject.Model;
using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using HMSRepository.Interface;
using HMSService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSService
{
    public class BookingReservationService : IBookingReservationService
    {
        private readonly IHelperService _helperService;
        private readonly IBookingReservationRepository _bookingReservationRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IAccountRepository _accountRepository;

        public BookingReservationService(IHelperService helperService, IBookingReservationRepository bookingReservationRepository, IRoleRepository roleRepository, IAccountRepository accountRepository)
        {
            _helperService = helperService;
            _bookingReservationRepository = bookingReservationRepository;
            _roleRepository = roleRepository;
            _accountRepository = accountRepository;
        }

        public async Task<bool> CreateBookingReservationAsync(CreateBookingReservationReqDto newBooking)
        {
            try
            {                
                BookingReservation newbooking = new()
                {
                    CustomerId = newBooking.CustomerId,
                    RoomInformationId = newBooking.RoomId,
                    StartDate = newBooking.StartDate,
                    EndDate = newBooking.EndDate,
                    ActualPrice = newBooking.ActualPrice,
                    Status = "ACTIVE"
                };
                return await _bookingReservationRepository.CreateBookingReservationAsync(newbooking);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetBookingReservationResDto>> CreateReportBookingReservationAsync(CreateReportBookingReservationReqDto createReportBookingReservationReqDto)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");
                var roleAdmin = await _roleRepository.GetRoleByAuthorityAsync("ADMIN") ?? throw new Exception("Role not found");
                if (accLogged.RoleId != roleAdmin.Id)
                {
                    throw new Exception("Unauthority");
                }
                var bookings = await _bookingReservationRepository.GetAllBookingReservationAsync();
                var result = bookings.Where(x => x.StartDate >= createReportBookingReservationReqDto.StartDate && x.EndDate <= createReportBookingReservationReqDto.EndDate).ToList();
                return result.Select(x => new GetBookingReservationResDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    RoomId = x.RoomInformationId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ActualPrice = x.ActualPrice,
                    Status = x.Status
                }).ToList();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteBookingReservationAsync(Guid bookingId)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");
                var roleAdmin = await _roleRepository.GetRoleByAuthorityAsync("ADMIN") ?? throw new Exception("Role not found");
                if (accLogged.RoleId != roleAdmin.Id)
                {
                    throw new Exception("Unauthority");
                }
                var booking = await _bookingReservationRepository.GetBookingReservationByIdAsync(bookingId) ?? throw new Exception("Booking not found");
                // Change status to DELETED
                booking.Status = "DELETED";
                return await _bookingReservationRepository.UpdateBookingReservationAsync(booking);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetBookingReservationResDto>> GetAllBookingReservationAsync()
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");
                var roleAdmin = await _roleRepository.GetRoleByAuthorityAsync("ADMIN") ?? throw new Exception("Role not found");
                if (accLogged.RoleId != roleAdmin.Id)
                {
                    throw new Exception("Unauthority");
                }
                var bookings = await _bookingReservationRepository.GetAllBookingReservationAsync();
                return bookings.Select(x => new GetBookingReservationResDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    RoomId = x.RoomInformationId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ActualPrice = x.ActualPrice,
                    Status = x.Status
                }).ToList();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetBookingReservationResDto>> GetBookingReservationByCustomerAsync()
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");

                var bookings = await _bookingReservationRepository.GetAllBookingReservationAsync();
                var result = bookings.Where(x => x.CustomerId == accLogged.Id).ToList();
                return result.Select(x => new GetBookingReservationResDto
                {
                    Id = x.Id,
                    CustomerId = x.CustomerId,
                    RoomId = x.RoomInformationId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    ActualPrice = x.ActualPrice,
                    Status = x.Status
                }).ToList();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateBookingReservationAsync(UpdateBookingReservationReqDto updateBooking)
        {
            try
            {
                if (!_helperService.IsTokenValid())
                {
                    throw new Exception("Unauthorized");
                }
                var accLogged = await _accountRepository.GetAccountByIdAsync(_helperService.GetAccIdFromLogged()) ?? throw new Exception("Unauthorized");
                var roleAdmin = await _roleRepository.GetRoleByAuthorityAsync("ADMIN") ?? throw new Exception("Role not found");
                if (accLogged.RoleId != roleAdmin.Id)
                {
                    throw new Exception("Unauthority");
                }
                BookingReservation booking = await _bookingReservationRepository.GetBookingReservationByIdAsync(updateBooking.Id) ?? throw new Exception("Booking not found");
                booking.CustomerId = updateBooking.CustomerId ?? booking.CustomerId;
                booking.RoomInformationId = updateBooking.RoomId ?? booking.RoomInformationId;
                booking.StartDate = updateBooking.StartDate ?? booking.StartDate;
                booking.EndDate = updateBooking.EndDate ?? booking.EndDate;
                booking.ActualPrice = updateBooking.ActualPrice ?? booking.ActualPrice;
                return await _bookingReservationRepository.UpdateBookingReservationAsync(booking);
            } catch (Exception)
            {
                throw;
            }
        }


    }
}
