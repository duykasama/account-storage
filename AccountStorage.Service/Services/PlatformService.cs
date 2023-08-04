using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountStorage.Service.Services
{
    public class PlatformService : IPlatformService
    {
        #region initialize context
        private readonly AccountDbContext _dbContext;
        
        public PlatformService()
        {
            _dbContext = new AccountDbContext();
        }
        #endregion

        public Task<Platform> CreatePlatformAsync(Platform platform)
        {
            throw new NotImplementedException();
        }

        public async Task<Platform?> GetPlatformByIdAsync(string id) => await _dbContext.Platforms
            .FindAsync(id);

        public async Task<Platform?> GetPlatformByNameAsync(string name) => await _dbContext.Platforms
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Name == name);

        public async Task<IEnumerable<Platform>> GetPlatformsAsync() => await _dbContext.Platforms
            .AsNoTracking()
            .ToListAsync();
    }
}
