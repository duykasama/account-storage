using AccountStorage.Service.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ICollection<Account>> GetAccountsAsync();
        Task<Account?> GetAccountByIdAsync(string id);
        Task<bool> DeleteAccountByIdAsync(string id);
        Task<bool> UpdateAccount(Account account);
        Task<bool> CreateAccountAsync(Account account);
    }
}
