using AccountStorage.Service.Entities;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account?> GetAccountByIdAsync(string id);
        Task<Account> DeleteAccount(string id);
        Task<Account> CreateAccount(Account account);
        Task<Account> UpdateAccount(Account account);
    }
}
