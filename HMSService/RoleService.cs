using HMSBuinessObject.Model;
using HMSBuinessObject.Model.ReponseDto;
using HMSBuinessObject.Model.RequestDto;
using HMSRepository.Interface;
using HMSService.Interface;

namespace HMSService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<bool> CreateRoleAsync(CreateRoleReqDto newRole)
        {
            try
            {
                Role role = new Role
                {
                    Authority = newRole.Authority
                };
                return _roleRepository.CreateRoleAsync(role);
            } catch (Exception)
            {
                throw;
            }
        }

        public Task<IEnumerable<GetRoleResDto>> GetAllRolesAsync()
        {
            try
            {
                IEnumerable<Role> roles = _roleRepository.GetAllRolesAsync().Result;
                return Task.FromResult(roles.Select(role => new GetRoleResDto
                {
                    Id = role.Id,
                    Name = role.Authority.ToUpper()
                }));
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
