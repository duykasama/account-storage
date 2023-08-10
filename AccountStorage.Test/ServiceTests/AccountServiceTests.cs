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
            var dbContext = new AccountDbContext();
            _accountService = new AccountService(dbContext);
            _platformService = new PlatformService(dbContext);
            _categorySevice = new CategoryService(dbContext);
        }

        [Fact]
        public void TestCreateAccount()
        {
            Platform platform = (_platformService.GetPlatforms()).First();
            Category category = (_categorySevice.GetCategories()).First();

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

            Assert.True(_accountService.CreateAccount(account));
        }

        [Fact] 
        public void TestCreateAccountWithExistingPlatformAndCategory() 
        {
            var platform = _platformService.GetPlatformByName("Facebook");
            var category = _categorySevice.GetCategoryByName("Social media");

            Assert.NotNull(platform);
            Assert.NotNull(category);

            var account = new Account()
            {
                AccountName = "New Account",
                Platform = platform,
                Category = category,
                Email = "myemail@gmail.com",
                Password = "Password",
                UserId = "9ead2d2b-a05b-40ea-9ef2-f0616aadf92c",
                CreationDate = DateTime.Now,
                LastModification = DateTime.Now,
            };

            Assert.True(_accountService.CreateAccount(account));
        }

        [Fact]
        public async void TestGetAccounts()
        {
            var accounts = _accountService.GetAccounts();
            Assert.NotNull(accounts);
            Assert.NotEmpty(accounts);
        }
        
        [Fact]
        public async void TestGetAccountById()
        {
            var account = _accountService.GetAccountById("83ece864-0a4a-4af9-8ca2-941f494f070e");
            Assert.NotNull(account);
        }
        
        [Fact]
        public async void TestDeleteAccountById()
        {
            Assert.True(await _accountService.DeleteAccountById("876f231a-38df-4d60-b114-34fca39ab8b5"));
        }
        
        [Fact]
        public async void TestUpdateAccount()
        {
            var account = _accountService.GetAccountById("83ece864-0a4a-4af9-8ca2-941f494f070e");
            Assert.NotNull(account);

            account.AccountName = "Thanh Duy";
            
            Assert.True(await _accountService.UpdateAccount(account));
        }
        
    }
}
