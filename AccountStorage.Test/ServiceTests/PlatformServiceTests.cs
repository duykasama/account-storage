using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountStorage.Test.ServiceTests
{

    public class PlatformServiceTests
    {
        private readonly AccountService _accountService;
        private readonly PlatformService _platformService;
        private readonly CategoryService _categorySevice;

        public PlatformServiceTests()
        {
            _accountService = new AccountService();
            _platformService = new PlatformService();
            _categorySevice = new CategoryService();
        }

        [Fact]
        public async void TestAddPlatform()
        {
            Platform platform = new Platform()
            {
                Name = "something",
                Url = "https://www.facebook.com",
                IsVerified = false,
            };

            Assert.True(await _platformService.CreatePlatformAsync(platform));
        }

        [Fact]
        public async void TestDeletePlatform()
        {
            var platform = _platformService.GetPlatformByName("something");

            Assert.NotNull(platform);

            if (platform is not null)
            {
                Assert.True(await _platformService.DeletePlatformAsync(platform));
            }
        }

        [Fact]
        public async void TestGetPlatformById()
        {
            var platform = await _platformService.GetPlatformByIdAsync("753de9e2-0e38-4b6f-a10e-53fc2f21d9fa");
            Assert.NotNull(platform);
        }

        [Fact]
        public void TestGetPlatformByName()
        {
            var platform = _platformService.GetPlatformByName("YouTube");
            Assert.NotNull(platform);
        }

        [Fact]
        public void TestGetPlatforms()
        {
            var platforms = _platformService.GetPlatforms();
            Assert.NotNull(platforms);
            Assert.NotEmpty(platforms);
        }

    }

}
