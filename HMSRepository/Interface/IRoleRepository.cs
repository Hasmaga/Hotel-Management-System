using HMSBuinessObject.Model;

namespace HMSRepository.Interface
{
    public interface IRoleRepository
    {
        Task<bool> CreateRoleAsync(Role role);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role?> GetRoleByAuthorityAsync(string authority);
    }
}
