using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountStorage.Service.Services
{
    public class PlatformService : IPlatformService
    {
        #region initialize dbcontext
        private readonly AccountDbContext _dbContext;
        
        public PlatformService()
        {
            _dbContext = new AccountDbContext();
        }
        #endregion

        public async Task<bool> CreatePlatformAsync(Platform platform)
        {
            var p = await GetPlatformByIdAsync(platform.Id);
            if (p is not null)
            {
                return false;
            }

            try
            {
                await _dbContext.Platforms.AddAsync(platform);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeletePlatformAsync(Platform platform)
        {
            var p = await GetPlatformByIdAsync(platform.Id);
            if (p is null)
            {
                return false;
            }

            try
            {
                _dbContext.Platforms.Remove(platform);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Platform?> GetPlatformByIdAsync(string id) => await _dbContext.Platforms
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id);

        public Platform? GetPlatformByName(string name) => _dbContext.Platforms
            .AsNoTracking()
            .FirstOrDefault(p => p.Name == name);

        public ICollection<Platform> GetPlatforms() => _dbContext.Platforms
            .AsNoTracking()
            .Where(p => p.IsVerified)
            .ToList();
    }
}
