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
    public class AccountRepository : IAccountRepository
    {
        private readonly HMSDBContexts _db;
        public AccountRepository(HMSDBContexts db)
        {
            _db = db;
        }

        public async Task<bool> CreateAccountAsync(Account account)
        {
            try
            {
                await _db.Accounts.AddAsync(account);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Account?> GetAccountByEmailAsync(string email)
        {
            try
            {
                return await _db.Accounts.FirstOrDefaultAsync(account => account.Email == email);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<Account?> GetAccountByIdAsync(Guid id)
        {
            try
            {
                return await _db.Accounts.FindAsync(id);
            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Account>> GetListAccountAsync()
        {
            try 
            {
                return await _db.Accounts.ToListAsync();
            } catch (Exception)
            {
                throw;
            }            
        }

        public async Task<bool> UpdateAccountAsync(Account account)
        {
            try
            {
                _db.Accounts.Update(account);
                await _db.SaveChangesAsync();
                return true;
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
