using AccountStorage.Service.Entities;

namespace AccountStorage.Service.Services.Interfaces
{
    public interface IPlatformService
    {
        ICollection<Platform> GetPlatforms();
        Task<Platform?> GetPlatformByIdAsync(string id);
        Platform? GetPlatformByName(string name);
        Task<bool> CreatePlatformAsync(Platform platform);
        Task<bool> DeletePlatformAsync(Platform platform);
    }
}
