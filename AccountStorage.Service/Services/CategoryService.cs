using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountStorage.Service.Services
{
    public class CategoryService : ICategoryService
    {
        #region initialize dbcontext
        private readonly AccountDbContext _dbContext;
        public CategoryService(AccountDbContextFactory dbContextFactory)
        {
            //_dbContext = new AccountDbContext();
            _dbContext = dbContextFactory.CreateDbContext(new string[] {});
        }
        #endregion

        public ICollection<Category> GetCategories() => _dbContext.Categories
            .AsNoTracking()
            .ToList();

        public async Task<Category?> GetCategoryByIdAsync(string id) => await _dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<bool> AddCategoriesAsync(ICollection<Category> categories)
        {
            try
            {
                await _dbContext.Categories.AddRangeAsync(categories);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Category? GetCategoryByName(string name) => _dbContext.Categories
            .AsNoTracking()
            .FirstOrDefault(c => c.Name == name);

        public async Task<bool> AddCategoryAsync(Category category)
        {
            var c = await GetCategoryByIdAsync(category.Id);
            if (c is not null)
            {
                return false;
            }

            try
            {
                await _dbContext.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<Category>> GetCategoriesAsync() => await _dbContext.Categories
            .AsNoTracking()
            .ToListAsync();
    }
}
