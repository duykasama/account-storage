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

        public bool CreateAccount(Account account)
        {
            var a = GetAccountByIdAsync(account.Id);
            if (a is not null)
            {
                return false;
            }

            try
            {
                _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAccountByIdAsync(string id)
        {
            var a = GetAccountByIdAsync(id);
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

        public Account? GetAccountByIdAsync(string id) => _dbContext.Accounts
            .Include(a => a.Platform)
            .Include(a => a.Category)
            .Include(a => a.User)
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == id);

        public ICollection<Account> GetAccountsAsync() => _dbContext.Accounts
            .Include(a => a.Platform)
            .AsNoTracking()
            .ToList();

        public async Task<bool> UpdateAccount(Account account)
        {
            var a = GetAccountByIdAsync(account.Id);
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
