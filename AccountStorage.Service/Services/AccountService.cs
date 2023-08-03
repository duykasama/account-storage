using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountStorage.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountDbContext _dbContext;
        public AccountService()
        {
            _dbContext = new AccountDbContext();
        }
        public Task<Account> CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Account> DeleteAccount(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetAccountByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync() => await _dbContext.Accounts
            .Include(a => a.Platform)
            .ToListAsync();

        public Task<Account> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
