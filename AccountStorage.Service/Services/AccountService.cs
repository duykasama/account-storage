using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccountStorage.Service.Services
{
    public class AccountService : IAccountService
    {
        #region initialize dbcontext
        private readonly AccountDbContext _dbContext;

        public AccountService()
        {
            _dbContext = new AccountDbContext();
        }
        #endregion

        public async Task CreateAccountAsync(Account account)
        {
            var a = await GetAccountByIdAsync(account.Id);
            if (a is not null)
            {
                throw new Exception("AccountId already exists");
            }

            try
            {
                _dbContext.Entry(account).State = EntityState.Modified;
                await _dbContext.Accounts.AddAsync(account);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception($"Failed to create account {account.AccountName}");
            }
        }

        public async Task DeleteAccountByIdAsync(string id)
        {
            var a = await GetAccountByIdAsync(id);
            if (a is null)
            {
                throw new Exception("AccountId doesn't exist");
            }

            try
            {
                _dbContext.Remove(a);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception($"Failed to delete account with {id}");
            }
        }

        public async Task<Account?> GetAccountByIdAsync(string id) => await _dbContext.Accounts.FindAsync(id);

        public ICollection<Account> GetAccounts() => _dbContext.Accounts.ToList();

        public async Task<ICollection<Account>> GetAccountsAsync() => await _dbContext.Accounts
            .Include(a => a.Platform)
            .ToListAsync();
        
        public async Task<Platform?> GetPlatformByNameAsync(string name) => await _dbContext.Platforms
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name == name);

        public async Task<IEnumerable<Platform>> GetPlatformsAsync() => await _dbContext.Platforms.AsNoTracking().ToListAsync();

        public Task<Account> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        
    }
}
