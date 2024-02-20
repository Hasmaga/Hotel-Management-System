using HMSBuinessObject.Model;

namespace HMSRepository.Interface
{
    public interface IAccountRepository
    {
        Task<Account?> GetAccountByEmailAsync(string email);
        Task<bool> CreateAccountAsync(Account account);
        Task<Account?> GetAccountByIdAsync(Guid id);
        Task<List<Account>> GetListAccountAsync();
        Task<bool> UpdateAccountAsync(Account account);
    }
}
