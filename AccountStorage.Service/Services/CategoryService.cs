﻿using AccountStorage.Service.Entities;
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

        public async Task<ICollection<Category>> GetCategoriesAsync() => await _dbContext.Categories
            .AsNoTracking()
            .ToListAsync();

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

        public async Task<Category?> GetCategoryByNameAsync(string name) => await _dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Name == name);

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
    }
}