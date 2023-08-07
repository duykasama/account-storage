using AccountStorage.Service.Entities;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(string id);
        Task<Category?> GetCategoryByNameAsync(string name);
        Task<bool> AddCategoriesAsync(ICollection<Category> categories);
        Task<bool> AddCategoryAsync(Category category);
    }
}
