using HMSBuinessObject.Model;
using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using HMSRepository;
using HMSRepository.Interface;
using HMSService.Interface;


namespace HMSService
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IHelperService _helperService;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IBookingReservationRepository _bookingReservationRepository;

        public RoomService(IRoomRepository roomRepository, IHelperService helperService, IAccountRepository accountRepository, IRoleRepository roleRepository, IRoomTypeRepository roomTypeRepository, IBookingReservationRepository bookingReservationRepository)
        {
            _roomRepository = roomRepository;
            _helperService = helperService;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
            _roomTypeRepository = roomTypeRepository;
            _bookingReservationRepository = bookingReservationRepository;
        }

        public async Task<bool> CreateRoomAsync(CreateRoomInformationReqDto newRoom)
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

                var roomType = await _roomTypeRepository.GetRoomTypeByName(newRoom.RoomType) ?? throw new Exception("Room type not found");

                RoomInformation room = new RoomInformation
                {
                    RoomName = newRoom.RoomName,
                    RoomCapacity = newRoom.RoomCapacity,
                    CreatedDate = DateOnly.FromDateTime(DateTime.Now),
                    RoomTypeID = roomType.Id,
                    BookingPrice = newRoom.BookingPrice,
                    Status = "ACTIVE"
                };
                return await _roomRepository.CreateRoomAsync(room);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteRoomAsync(Guid id)
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
                var room = await _roomRepository.GetRoomByIdAsync(id) ?? throw new Exception("Room not found");
                if (await _bookingReservationRepository.GetBookingReservationByRoomIdAsync(room.Id) != null)
                {
                    // Change status of room to DELETED
                    room.Status = "DELETED";
                    return await _roomRepository.UpdateRoomAsync(room);
                }
                return await _roomRepository.DeleteRoomAsync(room);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetRoomResDto>> GetListRoomAsync()
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
                var rooms = await _roomRepository.GetListRoomAsync();
                List<GetRoomResDto> res = new List<GetRoomResDto>();
                foreach (var room in rooms)
                {
                    var roomType = await _roomTypeRepository.GetRoomTypeByIdAsync(room.RoomTypeID) ?? throw new Exception("Room type not found");
                    res.Add(new GetRoomResDto
                    {
                        Id = room.Id,
                        RoomName = room.RoomName,
                        RoomCapacity = room.RoomCapacity,
                        CreatedDate = room.CreatedDate,
                        RoomType = roomType.RoomTypeName,
                        BookingPrice = room.BookingPrice,
                        Status = room.Status
                    });
                }
                return res;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateRoomAsync(UpdateRoomReqDto updateRoom)
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

                var room = await _roomRepository.GetRoomByIdAsync(updateRoom.Id) ?? throw new Exception("Room not found");
                var roomType = await _roomTypeRepository.GetRoomTypeByName(updateRoom.RoomType) ?? throw new Exception("Room type not found");
                if (roomType == null)
                {
                    throw new Exception("Room type not found");
                }
                room.RoomName = updateRoom.RoomName ?? room.RoomName;
                room.RoomCapacity = updateRoom.RoomCapacity ?? room.RoomCapacity;
                room.RoomTypeID = roomType.Id;
                room.BookingPrice = updateRoom.BookingPrice ?? room.BookingPrice;
                room.Status = updateRoom.Status ?? room.Status;
                return await _roomRepository.UpdateRoomAsync(room);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
