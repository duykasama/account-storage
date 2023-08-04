using AccountStorage.Service.Entities;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface IPlatformService
    {
        Task<IEnumerable<Platform>> GetPlatformsAsync();
        Task<Platform?> GetPlatformByIdAsync(string id);
        Task<Platform?> GetPlatformByNameAsync(string name);
        Task<Platform> CreatePlatformAsync(Platform platform);
    }
}
