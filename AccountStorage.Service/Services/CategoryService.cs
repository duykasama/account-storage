using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountStorage.Service.Services
{
    public class CategoryService : ICategoryService
    {
        #region initialize dbcontext
        private readonly AccountDbContext _dbContext;
        public CategoryService()
        {
            _dbContext = new AccountDbContext();
        }
        #endregion

        public async Task<IEnumerable<Category>> GetCategoriesAsync() => await _dbContext.Categories.ToListAsync();

        public async Task<Category?> GetCategoryByIdAsync(string id) => await _dbContext.Categories.FindAsync(id);

        public async Task AddCategories(ICollection<Category> categories)
        {
            await _dbContext.Categories.AddRangeAsync(categories);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category?> GetCategoryByNameAsync(string name) => await _dbContext.Categories
            .FirstOrDefaultAsync(c => c.Name == name);
    }
}
