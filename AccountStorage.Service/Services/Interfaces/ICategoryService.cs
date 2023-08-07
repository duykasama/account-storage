using AccountStorage.Service.Entities;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(string id);
        Task<Category?> GetCategoryByNameAsync(string name);
        Task AddCategories(ICollection<Category> categories);
    }
}
