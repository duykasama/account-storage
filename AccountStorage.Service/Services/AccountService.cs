﻿using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Xunit;

[assembly: TestFramework("AccountStorage.Clients.WebClients", "")]

namespace AccountStorage.Service.Services
{
    public class AccountService : IAccountService
    {
        #region initialize dbcontext
        private readonly AccountDbContext _dbContext;

        public AccountService(AccountDbContext dbContext)
        {
            //_dbContext = new AccountDbContext();
            _dbContext = dbContext;
        }
        #endregion

        public bool CreateAccount(Account account)
        {
            var a = GetAccountById(account.Id);
            if (a is not null)
            {
                return false;
            }

            try
            {
                _dbContext.Entry(account).State = EntityState.Modified;
                _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAccountById(string id)
        {
            var a = GetAccountById(id);
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

        public ICollection<Account> GetAccounts() => _dbContext.Accounts
            .Include(a => a.Platform)
            .AsNoTracking()
            .ToList();

        public async Task<bool> UpdateAccount(Account account)
        {
            var a = GetAccountById(account.Id);
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

        public Account? GetAccountById(string id) => _dbContext.Accounts
            .Include(a => a.Platform)
            .Include(a => a.Category)
            .Include(a => a.User)
            .AsNoTracking()
            .FirstOrDefault(a => a.Id == id);

        public Task<bool> CreateAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccountByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Account?> GetAccountByIdAsync(string id) => await _dbContext.Accounts
            .AsNoTracking()
            .FirstAsync();

        public async Task<ICollection<Account>> GetAccountsAsync() => await _dbContext.Accounts
            .Include(a => a.Platform)
            .Include(a => a.Category)
            .AsNoTracking()
            .ToListAsync();

        public Task<bool> UpdateAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public ICollection<Account> GetAccountsByUserId(string id) => _dbContext.Accounts
            .AsNoTracking()
            .Include(a => a.Platform)
            .Include(a => a.Category)
            .Where(a => a.UserId == id)
            .ToList();

        public async Task<ICollection<Account>> GetAccountsByUserIdAsync(string id) => await _dbContext.Accounts
            .AsNoTracking()
            .Include(a => a.Platform)
            .Include(a => a.Category)
            .Where(a => a.UserId == id)
            .ToListAsync();
    }
}
