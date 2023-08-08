using AccountStorage.Service.Entities;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface IPlatformService
    {
        ICollection<Platform> GetPlatforms();
        Task<Platform?> GetPlatformByIdAsync(string id);
        Task<Platform?> GetPlatformByNameAsync(string name);
        Task<bool> CreatePlatformAsync(Platform platform);
        Task<bool> DeletePlatformAsync(Platform platform);
    }
}
