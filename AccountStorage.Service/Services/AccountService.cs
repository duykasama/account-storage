using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccountStorage.Service.Services
{
    public class AccountService : IAccountService
    {
        #region initialize context
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
                await _dbContext.Accounts.AddAsync(account);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _dbContext.Remove(account);
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAccount(string id)
        {
            var a = await GetAccountByIdAsync(id);
            if (a is null)
            {
                throw new Exception("AccountId doesn't exist");
            }

            _dbContext.Remove(a);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Account?> GetAccountByIdAsync(string id) => await _dbContext.Accounts.FindAsync(id);

        public async Task<IEnumerable<Account>> GetAccountsAsync() => await _dbContext.Accounts
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
