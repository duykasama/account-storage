﻿using AccountStorage.Service.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface IAccountService
    {
        ICollection<Account> GetAccounts();
        ICollection<Account> GetAccountsByUserId(string id);
        Account? GetAccountById(string id);
        Task<bool> DeleteAccountById(string id);
        Task<bool> UpdateAccount(Account account);
        bool CreateAccount(Account account);
        Task<ICollection<Account>> GetAccountsAsync();
        Task<ICollection<Account>> GetAccountsByUserIdAsync(string id);
        Task<Account?> GetAccountByIdAsync(string id);
        Task<bool> DeleteAccountByIdAsync(string id);
        Task<bool> UpdateAccountAsync(Account account);
        Task<bool> CreateAccountAsync(Account account);
    }
}
