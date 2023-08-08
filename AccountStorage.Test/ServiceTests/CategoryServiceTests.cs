using AccountStorage.Service.Entities;
using AccountStorage.Service.Services;
using AccountStorage.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountStorage.Test.ServiceTests
{
    public class CategoryServiceTests
    {
        private readonly IAccountService _accountService;
        private readonly IPlatformService _platformService;
        private readonly ICategoryService _categorySevice;

        public CategoryServiceTests()
        {
            _accountService = new AccountService();
            _platformService = new PlatformService();
            _categorySevice = new CategoryService();
        }

        [Fact]
        public async void TestGetCategories()
        {
            var categories = _categorySevice.GetCategories();
            Assert.NotNull(categories);
            Assert.NotEmpty(categories);
        }

        [Fact]
        public async void TestGetCategoryById()
        {
            var category = await _categorySevice.GetCategoryByIdAsync("C01");
            Assert.NotNull(category);
        }

        [Fact]
        public async void TestGetCategoryByName()
        {
            var category = _categorySevice.GetCategoryByName("Social media");
            Assert.NotNull(category);
        }

        [Theory]
        [InlineData("Study")]
        [InlineData("Work")]
        [InlineData("Social media")]
        [InlineData("Game")]
        [InlineData("Entertainment")]
        [InlineData("Other")]
        public async void TestAddMultipleCategories(string categoryName)
        {
            List<Category> categories = new List<Category>()
            {
                new()
                {
                    Name = categoryName,
                },
            };

            Assert.True(await _categorySevice.AddCategoriesAsync(categories));
        }

        [Fact]
        public async void TestAddSingleCategory()
        {
            var category = new Category()
            {
                Name = "Study",
            };

            Assert.True(await _categorySevice.AddCategoryAsync(category));
        }
    }
}
