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

        public async Task<bool> CreateAccountAsync(Account account)
        {
            var a = await GetAccountByIdAsync(account.Id);
            if (a is not null)
            {
                return false;
            }

            try
            {
                _dbContext.Entry(account).State = EntityState.Modified;
                await _dbContext.Accounts.AddAsync(account);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAccountByIdAsync(string id)
        {
            var a = await GetAccountByIdAsync(id);
            if (a is null)
            {
                return false;
            }

            try
            {
                _dbContext.Remove(a);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Account?> GetAccountByIdAsync(string id) => await _dbContext.Accounts
            .Include(a => a.Platform)
            .Include(a => a.Category)
            .Include(a => a.User)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<ICollection<Account>> GetAccountsAsync() => await _dbContext.Accounts
            .Include(a => a.Platform)
            .AsNoTracking()
            .ToListAsync();

        public async Task<bool> UpdateAccount(Account account)
        {
            var a = await GetAccountByIdAsync(account.Id);
            if (a is null)
            {
                return false;
            }

            try
            {
                _dbContext.Accounts.Update(account);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
