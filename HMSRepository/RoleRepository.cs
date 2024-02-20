using HMSBuinessObject.HMSDbContext;
using HMSBuinessObject.Model;
using HMSRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HMSRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HMSDBContexts _db;
        public RoleRepository(HMSDBContexts db)
        {
            _db = db;
        }

        public async Task<bool> CreateRoleAsync(Role role)
        {
            try
            {
                await _db.Roles.AddAsync(role);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            try
            {
                return await _db.Roles.ToListAsync();
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Role?> GetRoleByAuthorityAsync(string authority)
        {
            try
            {
                return await _db.Roles.FirstOrDefaultAsync(role => role.Authority == authority);
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
