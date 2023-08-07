using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AccountStorage.Test.ServiceTests
{
    public class AccountServiceTests
    {
        private readonly AccountService _accountService;
        private readonly PlatformService _platformService;
        private readonly CategoryService _categorySevice;

        public AccountServiceTests()
        {
            _accountService = new AccountService();
            _platformService = new PlatformService();
            _categorySevice = new CategoryService();
        }

        [Fact]
        public async void TestCreateAccount()
        {
            Platform platform = (await _platformService.GetPlatformsAsync()).First();
            Category category = (await _categorySevice.GetCategoriesAsync()).First();

            Account account = new()
            {
                Id = Guid.NewGuid().ToString(),
                AccountName = "Test01",
                UserId = "9ead2d2b-a05b-40ea-9ef2-f0616aadf92c",
                //PlatformId = "P01",
                Platform = platform,
                Email = "Test01@gmail.com",
                Password = "Password",
                //CategoryId = "C01",
                Category = category,
                CreationDate = DateTime.Now,
                LastModification = DateTime.Now,
            };

            Assert.True(await _accountService.CreateAccountAsync(account));
        }

        [Fact]
        public async void TestGetAccounts()
        {
            var accounts = await _accountService.GetAccountsAsync();
            Assert.NotNull(accounts);
            Assert.NotEmpty(accounts);
        }
        
        [Fact]
        public async void TestGetAccountById()
        {
            var account = await _accountService.GetAccountByIdAsync("83ece864-0a4a-4af9-8ca2-941f494f070e");
            Assert.NotNull(account);
        }
        
        [Fact]
        public async void TestDeleteAccountById()
        {
            Assert.True(await _accountService.DeleteAccountByIdAsync("876f231a-38df-4d60-b114-34fca39ab8b5"));
        }
        
        [Fact]
        public async void TestUpdateAccount()
        {
            var account = await _accountService.GetAccountByIdAsync("83ece864-0a4a-4af9-8ca2-941f494f070e");
            Assert.NotNull(account);

            account.AccountName = "Thanh Duy";
            
            Assert.True(await _accountService.UpdateAccount(account));
        }
        
    }
}
