using AccountStorage.Service.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ICollection<Account>> GetAccountsAsync();
        Task<Account?> GetAccountByIdAsync(string id);
        Task DeleteAccountByIdAsync(string id);
        Task<Account> UpdateAccount(Account account);
        Task CreateAccountAsync(Account account);
        Task<Platform?> GetPlatformByNameAsync(string name);
        Task<IEnumerable<Platform>> GetPlatformsAsync();
        ICollection<Account> GetAccounts();
    }
}
