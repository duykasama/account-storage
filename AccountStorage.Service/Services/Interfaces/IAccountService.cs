using AccountStorage.Service.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface IAccountService
    {
        ICollection<Account> GetAccountsAsync();
        Account? GetAccountByIdAsync(string id);
        Task<bool> DeleteAccountByIdAsync(string id);
        Task<bool> UpdateAccount(Account account);
        bool CreateAccount(Account account);
    }
}
