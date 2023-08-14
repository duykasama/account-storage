using AccountStorage.Service.Entities;
using AccountStorage.Service.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AccountStorage.Service.Services
{
    public class SystemUserService : ISystemUserService
    {

        #region initialize dbcontext
        private readonly AccountDbContext _dbContext;

        public SystemUserService(AccountDbContextFactory dbContextFactory)
        {
            //_dbContext = new AccountDbContext();
            _dbContext = dbContextFactory.CreateDbContext(new string[] { });
        }
        #endregion
        public SystemUser? GetSystemUserById(string id) => _dbContext.SystemUsers
            .AsNoTracking()
            .FirstOrDefault(u => u.Id == id);

        public async Task<SystemUser?> GetSystemUserByIdAsync(string id) => await _dbContext.SystemUsers
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
