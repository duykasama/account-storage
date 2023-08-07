using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AccountStorage.Test
{
    public class AccountServiceTest
    {
        private readonly AccountService _accountService;
        private readonly PlatformService _platformService;
        private readonly CategoryService _categorySevice;

        public AccountServiceTest()
        {
            _accountService = new AccountService();
            _platformService = new PlatformService();
            _categorySevice = new CategoryService();
        }

        [Fact]
        public async void TestAddAccount()
        {
            //Platform platform = (await _platformService.GetPlatformsAsync()).First();
            //Category category = (await _categorySevice.GetCategoriesAsync()).First();

            Platform platform = new Platform()
            {
                Name = "Test platform",
            };

            Category category = new Category()
            {
                Name = "Test category",
            };

            Account account = new()
            {
                Id = Guid.NewGuid().ToString(),
                AccountName = "Test",
                UserId = "9ead2d2b-a05b-40ea-9ef2-f0616aadf92c",
                //PlatformId = "P01",
                Platform = platform,
                Email = "Test@gmail.com",
                Password = "Password",
                //CategoryId = "C01",
                Category = category,
                CreationDate = DateTime.Now,
                LastModification = DateTime.Now,
            };

            Assert.True(await _accountService.CreateAccountAsync(account));
        }

        [Fact]
        public async void TestAddPlatform()
        {
            Platform platform = new Platform()
            {
                Name = "YouTube",
                Url = "https://www.youtube.com",
                IsVerified = true,
            };

            Assert.True(await _platformService.CreatePlatformAsync(platform));
        }

        [Fact]
        public async void TestDeletePlatform()
        {
            var platform = await _platformService.GetPlatformByNameAsync("Facebook");

            Assert.NotNull(platform);

            if (platform is not null)
            {
                Assert.True(await _platformService.DeletePlatformAsync(platform));
            }
        }
    }
}
