using HMSBuinessObject.Model;
using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using HMSRepository;
using HMSRepository.Interface;
using HMSService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMSService
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IHelperService _helperService;
        private readonly IAccountRepository _accountRepository;
        private readonly IRoleRepository _roleRepository;
        public RoomTypeService(IRoomTypeRepository roomTypeRepository, IHelperService helperService, IAccountRepository accountRepository, IRoleRepository roleRepository)
        {
            _roomTypeRepository = roomTypeRepository;
            _helperService = helperService;
            _accountRepository = accountRepository;
            _roleRepository = roleRepository;
        }

        public async Task<bool> CreateRoomTypeAsync(CreateRoomTypeReqDto newRoomType)
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
                var roomType = new RoomType
                {
                    RoomTypeName = newRoomType.RoomTypeName,                    
                    RoomDescription = newRoomType.RoomTypeDescription
                };
                return await _roomTypeRepository.CreateRoomTypeAsync(roomType);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<GetRoomTypeResDto>> GetListRoomTypeAsync()
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
                var listRoomType = await _roomTypeRepository.GetListRoomTypeAsync();
                return listRoomType.Select(roomType => new GetRoomTypeResDto
                {
                    Id = roomType.Id,
                    RoomTypeName = roomType.RoomTypeName,
                    RoomTypeDescription = roomType.RoomDescription
                }).ToList();
            } catch (Exception)
            {
                throw;
            }
        }
    }   
}
